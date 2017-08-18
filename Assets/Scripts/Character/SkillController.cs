using System;
using System.Collections;
using UnityEngine;

abstract public class SkillController: MonoBehaviour {

    public void Play(Character source, Character target, Action onFinish) {
        StartCoroutine(SkillSteps(source, target, onFinish));
    }

    private IEnumerator SkillSteps(Character source, Character target, Action OnFinish) {
        yield return OnCast(source, target);
        Destroy(gameObject);
        OnFinish();
    }

    public abstract IEnumerator OnCast(Character source, Character target);
}