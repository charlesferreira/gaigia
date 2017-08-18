﻿public class CastSkillBattleState : IBattleState {

    public void OnStateEnter(IBattleStateMachine bsm) {
        bsm.ActiveCharacter.Skill.Cast(() => {
            bsm.SetState<PrepareNextTurnBattleState>();
        });
    }

    public void OnStateExit(IBattleStateMachine bsm) { }

    public void Update(IBattleStateMachine bsm) { }

}