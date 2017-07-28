using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField]
    private CharacterClass @class;

    private Weapon weapon;
    private Armor armor;

    public CharacterStats Stats { get; private set; }

    private void Start() {
        ResetStats();
    }

    private void ResetStats() {
        Stats = @class.Stats + weapon.Stats + armor.Stats;
    }

    public void Equip(Equipment equipment) {
        if (equipment is Weapon)
            weapon = (Weapon)equipment;
        else
            armor = (Armor)equipment;

        Stats += equipment.Stats;
        Inventory.Instance.Remove(equipment);
    }

    public void Remove(Equipment equipment) {
        if (equipment is Weapon)
            weapon = null;
        else
            armor = null;

        Stats -= equipment.Stats;
        Inventory.Instance.Add(equipment);
    }

}
