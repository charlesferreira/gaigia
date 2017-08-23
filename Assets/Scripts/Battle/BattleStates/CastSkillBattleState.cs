public class CastSkillBattleState : IBattleState {

    public void OnStateEnter(BattleManager bm) {
        bm.Character.Skill.Cast(bm.Character, bm.Target, () => {
            bm.SetState<PrepareNextTurnBattleState>();
        });
    }

    public void OnStateExit(BattleManager bm) { }

    public void Update(BattleManager bm) { }

}