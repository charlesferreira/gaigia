using UnityEngine;

[RequireComponent(typeof(SkillSet))]
[RequireComponent(typeof(CharacterHealth))]
[RequireComponent(typeof(CharacterMovement))]
public class Character : MonoBehaviour {

    [SerializeField] private Team team;
    [SerializeField] private Sprite avatar;
    [SerializeField] private StatsSheet baseStats;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Armor armor;

    private StatsSheet myStats;
    private SkillSet skillSet;
    private CharacterHealth health;
    private CharacterMovement movement;
    new private CharacterAnimations animation;

    public Team Team { get { return team; } }
    public Sprite Avatar { get { return avatar; } }
    public Weapon Weapon { get { return weapon ?? Weapon.Unarmed; } }
    public Armor Armor { get { return armor ?? Armor.Naked; } }

    public StatsSheet Stats { get { return myStats; } }
    public CharacterHealth Health { get { return health; } }
    public CharacterMovement Movement { get { return movement; } }
    public CharacterAnimations Animation { get { return animation; } }
    public Skill Skill { get { return skillSet.CurrentSkill; } }

    private StatsSheet BaseStats { get { return baseStats ?? StatsSheet.Blank; } }

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

    public void SelectNextSkill() {
        skillSet.SelectNextSkill();
    }

    public void SelectPreviousSkill() {
        skillSet.SelectPreviousSkill();
    }

    private void Awake() {
        skillSet = GetComponent<SkillSet>();
        health = GetComponent<CharacterHealth>();
        movement = GetComponent<CharacterMovement>();
        animation = GetComponentInChildren<CharacterAnimations>();
        CalculateStats();
    }

    private void CalculateStats() {
        myStats = BaseStats + Weapon.BonusStats + Armor.BonusStats;
    }
}
