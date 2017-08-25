using UnityEngine;

[CreateAssetMenu(menuName = "Equipment/Weapon")]
public class Weapon : Equipment {

    [Header("Weapon")]
    [SerializeField] private int attack;
    [Range(0, 5)]
    [SerializeField] private float range = 1;

    private static Weapon nullInstance;

    public static Weapon Unarmed {
        get {
            if (nullInstance == null)
                nullInstance = CreateInstance<Weapon>();
            return nullInstance;
        }
    }
    
    public int Attack { get { return attack; } }
    public float Range { get { return range; } }
}
