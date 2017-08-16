using UnityEngine;

[CreateAssetMenu(menuName = "Skill")]
public class Skill : ScriptableObject {
    
    [EnumFlags]
    [SerializeField] private TargetFlag targetFlag;
    [SerializeField] private Sprite icon;
    [SerializeField] private string _name;
    [Range(0f, 20)]
    [SerializeField] private float range;

    public Sprite Icon { get { return icon; } }
    public string Name { get { return _name; } }
    public float Range { get { return range; } }

    public bool Hits(Character target, Character source) {
        if (TargetsSelf(target, source))
            return true;
        
        return target.SqrDistance(source) < range * range
            && TeamsMatchTargetFlag(target, source);
    }

    private bool TargetsSelf(Character target, Character source) {
        return target == source && targetFlag.Match(TargetFlag.Self);
    }

    private bool TeamsMatchTargetFlag(Character target, Character source) {
        return target.Team == source.Team && targetFlag.Match(TargetFlag.Ally)
            || target.Team != source.Team && targetFlag.Match(TargetFlag.Enemy);
    }
}