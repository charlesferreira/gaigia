using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill")]
public class Skill : ScriptableObject {

    [EnumFlags]
    [SerializeField] private TargetFlag targetFlag;
    [SerializeField] private SkillController skillPrefab;
    [SerializeField] private Sprite icon;
    [SerializeField] private string _name;
    [Range(0f, 20)]
    [SerializeField] private float range;

    public Sprite Icon { get { return icon; } }
    public string Name { get { return _name; } }
    public float Range { get { return range; } }
    public Character Source { get; set; }
    public Character Target { get; set; }

    public void Reset() {
        Source = Target = null;
    }

    public void Cast(Action OnFinish) {
        var skill = Instantiate(skillPrefab);
        skill.Play(Source, Target, OnFinish);
    }

    public bool Hits(Character target) {
        if (TargetsSelf(target, Source))
            return true;
        
        return TargetIsInRange(target) && TeamsMatchTargetFlag(target, Source);
    }

    private bool TargetsSelf(Character target, Character source) {
        return target == source && targetFlag.Match(TargetFlag.Self);
    }

    private bool TargetIsInRange(Character target) {
        return target.SqrDistance(Source) < range * range;
    }

    private bool TeamsMatchTargetFlag(Character target, Character source) {
        return target.Team == source.Team && targetFlag.Match(TargetFlag.Ally)
            || target.Team != source.Team && targetFlag.Match(TargetFlag.Enemy);
    }
}