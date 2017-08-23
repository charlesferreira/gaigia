using UnityEngine;

[RequireComponent(typeof(ActionPoints))]
[RequireComponent(typeof(SkillSet))]
[RequireComponent(typeof(CharacterHealth))]
[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterAnimations))]
public class Character : MonoBehaviour {

    [SerializeField] private Team _team;
    [SerializeField] private Sprite _avatar;
    [SerializeField] private StatsSheet _baseStats;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Armor _armor;

    public ActionPoints AP { get; private set; }
    public SkillSet SkillSet { get; private set; }
    public CharacterHealth Health { get; private set; }
    public CharacterMovement Movement { get; private set; }
    public CharacterAnimations Animation { get; private set; }

    public StatsSheet Stats { get; private set; }
    public Skill Skill { get { return SkillSet.CurrentSkill; } }

    public Team Team { get { return _team; } }
    public Sprite Avatar { get { return _avatar; } }

    public bool HasEnoughAP() {
        return AP.Left >= Skill.GetCost(this);
    }

    public Weapon Weapon {
        get { return _weapon ?? Weapon.Unarmed; }
        private set { _weapon = value; }
    }

    public Armor Armor {
        get { return _armor ?? Armor.Naked; }
        private set { _armor = value; }
    }

    private StatsSheet BaseStats { get { return _baseStats ?? StatsSheet.Blank; } }

    public void SetActive(bool active) {
        Movement.SetActive(active);
        SkillSet.SetActive(active);
    }

    public void Equip(Weapon weapon) {
        Weapon = weapon;
        CalculateStats();
    }

    public void RemoveWeapon() {
        Weapon = Weapon.Unarmed;
        CalculateStats();
    }

    public void Equip(Armor armor) {
        Armor = armor;
        CalculateStats();
    }

    public void RemoveArmor() {
        Armor = Armor.Naked;
        CalculateStats();
    }

    public void SelectNextSkill(SkillRange skillRange) {
        SkillSet.SelectNextSkill();
        skillRange.SetRange(Skill.GetRange(this));
    }

    public void SelectPreviousSkill(SkillRange skillRange) {
        SkillSet.SelectPreviousSkill();
        skillRange.SetRange(Skill.GetRange(this));
    }

    private void Awake() {
        AP = GetComponent<ActionPoints>();
        SkillSet = GetComponent<SkillSet>();
        Health = GetComponent<CharacterHealth>();
        Movement = GetComponent<CharacterMovement>();
        Animation = GetComponent<CharacterAnimations>();
        CalculateStats();
    }

    private void CalculateStats() {
        Stats = BaseStats + Weapon.BonusStats + Armor.BonusStats;
    }
}
