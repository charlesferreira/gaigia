using UnityEngine;

[CreateAssetMenu(menuName = "Equipment/Armor")]
public class Armor : Equipment {

    [Header("Armor")]
    [SerializeField] private int defense;

    private static Armor nullInstance;

    public static Armor Naked {
        get {
            if (nullInstance == null)
                nullInstance = CreateInstance<Armor>();
            return nullInstance;
        }
    }

    public int Defense { get { return defense; } }

}
