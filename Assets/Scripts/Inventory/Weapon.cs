using UnityEngine;

[CreateAssetMenu(menuName = "Equipment/Weapon")]
public class Weapon : Equipment {

    [Header("Weapon")]
    [SerializeField] private string _name = "Unarmed";
    [SerializeField] private Sprite icon;
    [SerializeField] private int attack;
    [Range(0, 5)]
    [SerializeField] private float range;

    private static Weapon nullInstance;

    public static Weapon Unarmed {
        get {
            if (nullInstance == null)
                nullInstance = CreateInstance<Weapon>();
            return nullInstance;
        }
    }

    public string Name { get { return _name; } }
    public Sprite Icon { get { return icon; } }
    public int Attack { get { return attack; } }
    public float Range { get { return range; } }
}
