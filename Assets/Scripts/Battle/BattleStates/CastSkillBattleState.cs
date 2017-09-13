public class CastSkillBattleState : ISimpleState<BattleManager> {

    public void OnStateEnter(BattleManager bm) {
        bm.Character.Skill.Cast(bm.Character, bm.Target, () => {
            bm.SetState<EndOfTurnBattleState>();
        });
    }

    public void OnStateExit(BattleManager bm) { }

    public void Update(BattleManager bm) { }

}