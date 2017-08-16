public interface IBattleState {

    void OnStateEnter(IBattleStateMachine fsm);

    void OnStateExit(IBattleStateMachine battleManager);

    void Update(IBattleStateMachine fsm);

    void FixedUpdate(IBattleStateMachine fsm);
}