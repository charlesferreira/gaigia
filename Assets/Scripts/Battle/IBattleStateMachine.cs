public interface IBattleStateMachine {

    Character CurrentCharacter { get; }

    void SetState<T>() where T : IBattleState;
    
}
