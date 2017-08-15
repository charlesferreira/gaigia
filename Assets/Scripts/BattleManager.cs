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
        currentState = states.OfType<T>().First();
        currentState.OnStateEnter(this);
    }

    private void SetUpStates() {
        states = new List<IBattleState> {
            new InputBattleState(),
            new SetUpBattleState(),
        };
        SetState<SetUpBattleState>();
    }

    private void Start() {
        activeCharacterIndex = -1;
        SelectNextCharacter();
    }

    private void Update() {
        if (PlayerInput.Confirm) {
            SelectNextCharacter();
        }
    }

    private void SelectNextCharacter() {
        activeCharacterIndex += 1;
        activeCharacterIndex %= characters.Count;
        ActivateCurrentCharacter();
    }

    private void ActivateCurrentCharacter() {
        for (var i = 0; i < characters.Count; i++) {
            characters[i].SetActive(i == activeCharacterIndex);
        }
        MovementArea.Instance.SetUp(ActiveCharacter);
        SkillRange.Instance.SetUp(ActiveCharacter);
        SkillSetHUD.Instance.SetUp(ActiveCharacter.GetComponent<SkillSet>());
        BattleCamera.Instance.SetUp(ActiveCharacter.transform);
        ActionSequence.Instance.SetUp(ActiveCharacter);
    }
}
