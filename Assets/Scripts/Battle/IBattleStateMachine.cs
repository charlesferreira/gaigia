public interface IBattleStateMachine {

    Character ActiveCharacter { get; }

    void SetState<T>() where T : IBattleState;

    void SelectNextCharacter();
}
