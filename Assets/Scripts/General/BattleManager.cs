using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>, IBattleStateMachine {

    [SerializeField] private List<Character> characters;

    private IList<IBattleState> states;
    private IBattleState currentState;

    int activeCharacterIndex;

    public Character ActiveCharacter { get { return characters[activeCharacterIndex]; } }
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

    private void SetUpStates() {
        states = new List<IBattleState> {
            new SetUpBattleState(),
            new SelectSkillAndPositionBattleState(),
            new SelectTargetBattleState(),
        };
        SetState<SetUpBattleState>();
    }

    private void Awake() {
        SetUpStates();
    }

    private void Start() {
        ActivateCurrentCharacter();
    }

    private void Update() {
        currentState.Update(this);
    }

    private void FixedUpdate() {
        currentState.FixedUpdate(this);
    }

    private void ActivateCurrentCharacter() {
        for (var i = 0; i < characters.Count; i++) {
            characters[i].SetActive(i == activeCharacterIndex);
        }

        MovementArea.Instance.SetUp(ActiveCharacter);
        SkillRange.Instance.SetUp(ActiveCharacter);
        SkillSetHUD.Instance.SetUp(ActiveCharacter.GetComponent<SkillSet>());
        BattleCamera.Instance.SetTarget(ActiveCharacter.transform);
        ActionSequence.Instance.SetUp(ActiveCharacter);
    }
}
