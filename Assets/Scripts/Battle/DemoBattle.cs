using UnityEngine;

public class DemoBattle : MonoBehaviour {

    [SerializeField] private Party enemyParty;

    private void Awake() {
        CombatInfo.Instance.EnemyParty = enemyParty;
    }

}
