using UnityEngine;

public class DemoBattle : MonoBehaviour {

    public Party enemyParty;

    private void Start() {
        BattleManager.Instance.StartBattle(enemyParty);
    }
}
