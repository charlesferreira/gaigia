using UnityEngine;

[CreateAssetMenu(menuName = "Equipment/Armor")]
public class Armor : Equipment {

    [Header("Armor")]
    [SerializeField] private int defense;

    public int Defense { get { return defense; } }

}
