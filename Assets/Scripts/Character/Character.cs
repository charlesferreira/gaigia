using UnityEngine;

[RequireComponent(typeof(ActionPoints))]
[RequireComponent(typeof(SkillSet))]
[RequireComponent(typeof(CharacterHealth))]
[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterAnimations))]
public class Character : MonoBehaviour {
    
    private StatsSheet _baseStats;
    private Weapon _weapon;
    private Armor _armor;

    public ActionPoints AP { get; private set; }
    public SkillSet SkillSet { get; private set; }
    public CharacterHealth Health { get; private set; }
    public CharacterMovement Movement { get; private set; }
    public CharacterAnimations Animation { get; private set; }

    public StatsSheet Stats { get; private set; }
    public Skill Skill { get { return SkillSet.CurrentSkill; } }

    public Team Team { get; private set; }
    public Sprite Avatar { get; private set; }

    public bool IsAlive { get { return Health.HP > 0; } }

    public bool HasEnoughAP() { return AP.Left >= Skill.GetCost(this); }

    public Weapon Weapon {
        get { return _weapon ?? Weapon.Unarmed; }
        private set {
            _weapon = value ?? Weapon.Unarmed;
            CalculateStats();
        }
    }

    public Armor Armor {
        get { return _armor ?? Armor.Naked; }
        private set {
            _armor = value ?? Armor.Naked;
            CalculateStats();
        }
    }

    private StatsSheet BaseStats {
        get { return _baseStats ?? StatsSheet.Blank; }
        set {
            _baseStats = value;
            CalculateStats();
        }
    }

    public void SetActive(bool active) {
        Movement.SetActive(active);
        SkillSet.SetActive(active);
    }

    public void Equip(Weapon weapon) {
        Weapon = weapon;
    }

    public void RemoveWeapon() {
        Weapon = Weapon.Unarmed;
    }

    public void Equip(Armor armor) {
        Armor = armor;
    }

    public void RemoveArmor() {
        Armor = Armor.Naked;
    }

    public void SelectNextSkill(SkillRange skillRange) {
        SkillSet.SelectNextSkill();
        skillRange.SetRange(Skill.GetRange(this));
    }

    public void SelectPreviousSkill(SkillRange skillRange) {
        SkillSet.SelectPreviousSkill();
        skillRange.SetRange(Skill.GetRange(this));
    }

    public void SetUp(CharacterPreset info, Team team) {
        Avatar = info.Avatar;
        Team = team;
        BaseStats = info.BaseStats;
        Weapon = info.Weapon ?? Weapon.Unarmed;
        Armor = info.Armor;

        SkillSet.SetUp(info.Skills);
        Animation.SetUp(info.AnimatorController);
        Health.SetUp();
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
