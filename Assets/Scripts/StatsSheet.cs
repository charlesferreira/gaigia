using UnityEngine;

[CreateAssetMenu(menuName = "Stats Sheet")]
public class StatsSheet : ScriptableObject {

    [Header("Primary")]
    [SerializeField] private int vitality;
    [SerializeField] private int mana;
    [SerializeField] private int strength;
    [SerializeField] private int spirit;
    [SerializeField] private int dexterity;
    [SerializeField] private int charisma;
    [SerializeField] private int luck;

    [Header("Secondary")]
    [SerializeField] private int baseMovement;
    [SerializeField] private int baseEnergy;

    private static StatsSheet nullInstance;

    public static StatsSheet Blank {
        get {
            if (nullInstance == null)
                nullInstance = CreateInstance<StatsSheet>();
            return nullInstance;
        }
    }

    public int Vitality  { get { return vitality; } }
    public int Mana      { get { return mana; } }
    public int Strength  { get { return strength; } }
    public int Spirit    { get { return spirit; } }
    public int Dexterity { get { return dexterity; } }
    public int Charisma  { get { return charisma; } }
    public int Luck      { get { return luck; } }
    public int Movement  { get { return baseMovement + Dexterity; } }
    public int Energy    { get { return baseEnergy + Mana; } }
    public int MaxHp     { get { return vitality + strength; } }

    public static StatsSheet operator +(StatsSheet a, StatsSheet b) {
        var stats = CreateInstance<StatsSheet>();
        stats.vitality = a.vitality + b.vitality;
        stats.mana = a.mana + b.mana;
        stats.strength = a.strength + b.strength;
        stats.spirit = a.spirit + b.spirit;
        stats.dexterity = a.dexterity + b.dexterity;
        stats.charisma = a.charisma + b.charisma;
        stats.luck = a.luck + b.luck;
        stats.baseMovement = a.baseMovement + b.baseMovement;
        stats.baseEnergy = a.baseEnergy + b.baseEnergy;
        return stats;
    }
}
