using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>, IBattleStateMachine {

    [SerializeField] private List<Character> characters;

    int activeCharacterIndex;
    private List<Character> targets;
    private IBattleState currentState;
    private IList<IBattleState> states;
    
    public Character ActiveCharacter { get { return characters[activeCharacterIndex]; } }
    public IList<Character> Targets { get { return targets.AsReadOnly(); } }
    public IList<Character> Characters { get { return characters.AsReadOnly(); } }

    public void SetState<T>() where T : IBattleState {
        if (currentState != null)
            currentState.OnStateExit(this);
        currentState = states.OfType<T>().First();
        currentState.OnStateEnter(this);
    }

    public void SelectNextCharacter() {
        activeCharacterIndex += 1;
        activeCharacterIndex %= characters.Count;
        ActivateCurrentCharacter();
    }

    public void UpdateTargets() {
        targets = characters
            .Where(x => ActiveCharacter.Skill.Hits(x, ActiveCharacter))
            .OrderBy(x => x.SqrDistance(ActiveCharacter)).ToList();
    }

    private void SetUpStates() {
        states = new List<IBattleState> {
            new SetUpBattleState(),
            new PrepareNextTurnBattleState(),
            new SelectSkillAndPositionBattleState(),
            new SelectTargetBattleState(),
            new ExecuteSkillBattleState(),
        };
        SetState<SetUpBattleState>();
    }

    public void ActivateCurrentCharacter() {
        for (var i = 0; i < characters.Count; i++)
            characters[i].SetActive(i == activeCharacterIndex);
    }

    private void Awake() {
        targets = new List<Character>();
    }

    private void Start() {
        SetUpStates();
    }

    private void Update() {
        currentState.Update(this);
    }
}
