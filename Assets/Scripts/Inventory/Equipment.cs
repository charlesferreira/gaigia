using UnityEngine;

public class Equipment : Item {

    [SerializeField] private StatsSheet bonusStats;

    public StatsSheet BonusStats { get { return bonusStats ?? StatsSheet.Blank; } }

}
