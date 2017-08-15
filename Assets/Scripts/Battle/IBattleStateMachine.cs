public interface IBattleStateMachine {

    void SetState<T>() where T : IBattleState;
    
}
