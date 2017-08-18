﻿public class SetUpBattleState : IBattleState {

    public void OnStateEnter(IBattleStateMachine bsm) {
        bsm.SetState<PrepareNextTurnBattleState>();
    }

    public void OnStateExit(IBattleStateMachine bsm) { }

    public void Update(IBattleStateMachine bsm) { }
}