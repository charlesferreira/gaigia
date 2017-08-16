using UnityEngine;

[CreateAssetMenu(menuName = "Skill")]
public class Skill : ScriptableObject {

    [SerializeField] private Sprite icon;
    [SerializeField] private string _name;
    [Range(0, 50)] // 50? testar
    [SerializeField] private float range;

    public Sprite Icon { get { return icon; } }
    public string Name { get { return _name; } }
    public float Range { get { return range; } }
}