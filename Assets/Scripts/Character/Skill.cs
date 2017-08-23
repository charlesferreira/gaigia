using System;
using System.Collections;
using UnityEngine;

abstract public class Skill : MonoBehaviour {

    [EnumFlags]
    [SerializeField] private TargetFlag targetFlag;

    abstract public IEnumerator OnCast(Character source, Character target);
    abstract public Sprite GetIcon(Character character);
    abstract public string GetName(Character character);
    abstract public float GetRange(Character character);
    abstract public int GetCost(Character character);

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
        var range = GetRange(source);
        return target.SqrDistance(source) < range * range;
    }

    private bool TeamsMatchTargetFlag(Character source, Character target) {
        return source.Team == target.Team && targetFlag.Match(TargetFlag.Ally)
            || source.Team != target.Team && targetFlag.Match(TargetFlag.Enemy);
    }

    private IEnumerator SkillSteps(GameObject skill, Character source, Character target, Action OnFinish) {
        yield return OnCast(source, target);

        yield return new WaitForSeconds(1f);
        Destroy(skill);
        OnFinish();
    }
}