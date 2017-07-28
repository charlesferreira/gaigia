using UnityEngine;

[CreateAssetMenu(menuName = "Character/Class")]
public class CharacterClass : ScriptableObject {

    [SerializeField]
    private CharacterStats stats;

    public CharacterStats Stats { get { return stats; } }

}
