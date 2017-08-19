using System;
using System.Collections;
using UnityEngine;

abstract public class Skill : MonoBehaviour {

    [EnumFlags]
    [SerializeField] private TargetFlag targetFlag;

    abstract public string Name { get; }
    abstract public Sprite Icon { get; }
    abstract public float Range { get; }
    abstract public int Cost { get; }

    abstract public IEnumerator OnCast(Character source, Character target);

    public void Cast(Character source, Character target, Action OnFinish) {
        var skill = Instantiate(gameObject).GetComponent<Skill>();
        skill.StartCoroutine(SkillSteps(skill.gameObject, source, target, OnFinish));
    }

    public bool Hits(Character source, Character target) {
        if (TargetsSelf(source, target))
            return true;
        
        return TargetIsInRange(source, target) && TeamsMatchTargetFlag(source, target);
    }

    private bool TargetsSelf(Character source, Character target) {
        return target == source && targetFlag.Match(TargetFlag.Self);
    }

    private bool TargetIsInRange(Character source, Character target) {
        return target.SqrDistance(source) < Range * Range;
    }

    private bool TeamsMatchTargetFlag(Character source, Character target) {
        return source.Team == target.Team && targetFlag.Match(TargetFlag.Ally)
            || source.Team != target.Team && targetFlag.Match(TargetFlag.Enemy);
    }

    private IEnumerator SkillSteps(GameObject skill, Character source, Character target, Action OnFinish) {
        yield return OnCast(source, target);
        Destroy(skill);
        OnFinish();
    }
}