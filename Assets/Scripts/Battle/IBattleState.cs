public interface IBattleState {

    void OnStateEnter(IBattleStateMachine fsm);

    void Update(IBattleStateMachine fsm);

}