using System;
using UnityEngine;

[Serializable]
public struct CharacterStats {

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

    public int Vitality  { get { return vitality; } }
    public int Mana      { get { return mana; } }
    public int Strength  { get { return strength; } }
    public int Spirit    { get { return spirit; } }
    public int Dexterity { get { return dexterity; } }
    public int Charisma  { get { return charisma; } }
    public int Luck      { get { return luck; } }
    public int Movement  { get { return baseMovement + Dexterity; } }
    public int Energy    { get { return baseEnergy + Mana; } }

    public static CharacterStats operator +(CharacterStats lhs, CharacterStats rhs) {
        return new CharacterStats() {
            vitality = lhs.vitality + rhs.vitality,
            mana = lhs.mana + rhs.mana,
            strength = lhs.strength + rhs.strength,
            spirit = lhs.spirit + rhs.spirit,
            dexterity = lhs.dexterity + rhs.dexterity,
            charisma = lhs.charisma + rhs.charisma,
            luck = lhs.luck + rhs.luck,
            baseMovement = lhs.baseMovement + rhs.baseMovement,
            baseEnergy = lhs.baseEnergy + rhs.baseEnergy
        };
    }

    public static CharacterStats operator -(CharacterStats lhs, CharacterStats rhs) {
        return new CharacterStats() {
            vitality = lhs.vitality - rhs.vitality,
            mana = lhs.mana - rhs.mana,
            strength = lhs.strength - rhs.strength,
            spirit = lhs.spirit - rhs.spirit,
            dexterity = lhs.dexterity - rhs.dexterity,
            charisma = lhs.charisma - rhs.charisma,
            luck = lhs.luck - rhs.luck,
            baseMovement = lhs.baseMovement - rhs.baseMovement,
            baseEnergy = lhs.baseEnergy - rhs.baseEnergy
        };
    }

}
