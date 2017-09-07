using UnityEngine;

[CreateAssetMenu(menuName = "Character/Stats Sheet")]
public class StatsSheet : ScriptableObject {

    [Header("Primary")]
    [SerializeField] private int vitality;
    [SerializeField] private int mana;
    [SerializeField] private int strength;
    [SerializeField] private int mind;
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
    public int Mind      { get { return mind; } }
    public int Dexterity { get { return dexterity; } }
    public int Charisma  { get { return charisma; } }
    public int Luck      { get { return luck; } }
    public int Movement  { get { return baseMovement + dexterity; } }
    public int Energy    { get { return baseEnergy + mana; } }
    public int MaxHP     { get { return Vitality + strength; } }
    public int MaxME     { get { return mana + mind; } }

    public static StatsSheet operator +(StatsSheet a, StatsSheet b) {
        var stats = CreateInstance<StatsSheet>();
        stats.vitality = a.vitality + b.vitality;
        stats.mana = a.mana + b.mana;
        stats.strength = a.strength + b.strength;
        stats.mind = a.mind + b.mind;
        stats.dexterity = a.dexterity + b.dexterity;
        stats.charisma = a.charisma + b.charisma;
        stats.luck = a.luck + b.luck;
        stats.baseMovement = a.baseMovement + b.baseMovement;
        stats.baseEnergy = a.baseEnergy + b.baseEnergy;
        return stats;
    }
}
