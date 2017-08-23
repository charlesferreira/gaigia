public interface IBattleState {

    void OnStateEnter(BattleManager bm);

    void OnStateExit(BattleManager bm);

    void Update(BattleManager bm);
}