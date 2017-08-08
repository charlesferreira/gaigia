using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField] private StatsSheet baseStats;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Armor armor;

    private StatsSheet myStats;
    private int hp;

    public StatsSheet BaseStats { get { return baseStats ?? StatsSheet.Blank; } }
    public Weapon Weapon { get { return weapon ?? Weapon.Unarmed; } }
    public Armor Armor { get { return armor ?? Armor.Naked; } }

    public int Hp { get { return hp; } }

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
        ReplenishLifeAndEnergy();
    }

    private void CalculateStats() {
        myStats = BaseStats + Weapon.BonusStats + Armor.BonusStats;
        print(myStats.Vitality);
    }

    private void ReplenishLifeAndEnergy() {
        hp = myStats.MaxHp;
    }
}
