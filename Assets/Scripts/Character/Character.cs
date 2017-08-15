using UnityEngine;

[RequireComponent(typeof(SkillSet))]
[RequireComponent(typeof(CharacterMovement))]
public class Character : MonoBehaviour {

    [SerializeField] private TeamFlag teamFlag;
    [SerializeField] private StatsSheet baseStats;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Armor armor;
    [SerializeField] private Sprite avatar;

    private StatsSheet myStats;

    SkillSet skillSet;
    CharacterMovement movement;

    public TeamFlag TeamFlag { get { return teamFlag; } }
    public StatsSheet Stats { get { return myStats; } }
    public Sprite Avatar { get { return avatar; } }

    private StatsSheet BaseStats { get { return baseStats ?? StatsSheet.Blank; } }
    private Weapon Weapon { get { return weapon ?? Weapon.Unarmed; } }
    private Armor Armor { get { return armor ?? Armor.Naked; } }

    public void SetActive(bool active) {
        movement.SetActive(active);
        skillSet.SetActive(active);
    }

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
        skillSet = GetComponent<SkillSet>();
        movement = GetComponent<CharacterMovement>();
        CalculateStats();
    }

    private void CalculateStats() {
        myStats = BaseStats + Weapon.BonusStats + Armor.BonusStats;
    }
}
