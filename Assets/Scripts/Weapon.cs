using UnityEngine;

[CreateAssetMenu(menuName = "Equipment/Weapon")]
public class Weapon : Equipment {

    [Header("Weapon")]
    [SerializeField] private int attack;

    public int Attack { get { return attack; } }

}
