using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>, IBattleStateMachine {

    [SerializeField] private List<Character> characters;

    private IBattleState currentState;
    private IList<IBattleState> states;
    int activeCharacterIndex;
    int selectedTargetIndex;

    public Character ActiveCharacter { get { return characters[activeCharacterIndex]; } }
    public Character SelectedTarget { get { return Targets[selectedTargetIndex]; } }
    public IList<Character> Characters { get { return characters.AsReadOnly(); } }
    public IList<Character> Targets { get; set; }

    public void Reset() {
        activeCharacterIndex = -1;
        SetState<PrepareNextTurnBattleState>();
    }

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

    private void SetUpStates() {
        states = new List<IBattleState> {
            new SetUpBattleState(),
            new PrepareNextTurnBattleState(),
            new SetSkillAndPositionBattleState(),
            new SelectTargetBattleState(),
            new CastSkillBattleState(),
        };
        SetState<SetUpBattleState>();
    }

    public void ActivateCurrentCharacter() {
        for (var i = 0; i < characters.Count; i++)
            characters[i].SetActive(i == activeCharacterIndex);
    }

    public void ResetTarget() {
        selectedTargetIndex = 0;
    }

    public void UpdateTargets() {
        Targets = Characters
            .Where(x => ActiveCharacter.Skill.Hits(ActiveCharacter, x))
            .OrderBy(x => x.SqrDistance(ActiveCharacter)).ToList();
    }

    public void SelectNextTarget() {
        selectedTargetIndex += 1;
        selectedTargetIndex %= Targets.Count;
    }

    public void SelectPreviousTarget() {
        selectedTargetIndex += Targets.Count - 1;
        selectedTargetIndex %= Targets.Count;
    }

    private void Awake() {
        Targets = new List<Character>();
    }

    private void Start() {
        SetUpStates();
    }

    private void Update() {
        currentState.Update(this);
    }
}
