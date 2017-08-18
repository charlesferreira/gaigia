using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>, IBattleStateMachine {

    [SerializeField] private List<Character> characters;

    private IBattleState currentState;
    private IList<IBattleState> states;
    int activeCharacterIndex;
    
    public Character ActiveCharacter { get { return characters[activeCharacterIndex]; } }
    public IList<Character> Characters { get { return characters.AsReadOnly(); } }
    public IList<Character> Targets { get; set; }

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
            new SelectSkillAndPositionBattleState(),
            new SelectTargetBattleState(),
            new CastSkillBattleState(),
        };
        SetState<SetUpBattleState>();
    }

    public void ActivateCurrentCharacter() {
        for (var i = 0; i < characters.Count; i++)
            characters[i].SetActive(i == activeCharacterIndex);
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
