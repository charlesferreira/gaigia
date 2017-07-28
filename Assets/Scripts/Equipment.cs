using UnityEngine;

public class Equipment : Item {

    [SerializeField]
    private CharacterStats stats;

    public CharacterStats Stats { get { return stats; } }

}
