public interface IBattleState {

    void OnStateEnter(IBattleStateMachine bsm);

    void OnStateExit(IBattleStateMachine bsm);

    void Update(IBattleStateMachine bsm);
}