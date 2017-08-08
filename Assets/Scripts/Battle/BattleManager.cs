using System.Collections.Generic;
using System.Linq;

public class BattleManager : Singleton<BattleManager>, IBattleStateMachine {

    private IList<IBattleState> states;
    private IBattleState currentState;

    private IList<Character> characters;
    private Character currentCharacter;

    public Character CurrentCharacter { get { return currentCharacter; } }

    protected BattleManager() { }

    public void StartBattle(Party enemyParty) {
        characters = enemyParty.Members;
        foreach (var enemyPrefab in enemyParty.Members) {
            var enemy = Instantiate(enemyPrefab);
            characters.Add(enemy);
        }

        print(characters.Count);
    }

    public void SetState<T>() where T : IBattleState {
        currentState = states.OfType<T>().First();
        currentState.OnStateEnter(this);
    }

    private void Start() {
        SetUpStates();
    }

    private void SetUpStates() {
        states = new List<IBattleState> {
            new InputBattleState(),
            new SetUpBattleState(),
        };
        SetState<SetUpBattleState>();
    }

    private void Update() {
        currentState.Update(this);
    }

}