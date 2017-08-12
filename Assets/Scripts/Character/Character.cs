using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField] private TeamFlag teamFlag;
    [SerializeField] private StatsSheet baseStats;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Armor armor;

    private StatsSheet myStats;

    public StatsSheet Stats { get { return myStats; } }
    public TeamFlag TeamFlag { get { return teamFlag; } }

    private StatsSheet BaseStats { get { return baseStats ?? StatsSheet.Blank; } }
    private Weapon Weapon { get { return weapon ?? Weapon.Unarmed; } }
    private Armor Armor { get { return armor ?? Armor.Naked; } }

    public void Equip(Weapon weapon) {
        this.weapon = weapon;
        CalculateStats();
    }

    public void RemoveWeapon() {
        weapon = Weapon.Unarmed;
        CalculateStats();
    }

    public void Equip(Armor armor) {
        this.armor = armor;
        CalculateStats();
    }

    public void RemoveArmor() {
        armor = Armor.Naked;
        CalculateStats();
    }

    private void Awake() {
        CalculateStats();
    }

    private void CalculateStats() {
        myStats = BaseStats + Weapon.BonusStats + Armor.BonusStats;
        print(myStats.Vitality);
    }
}
