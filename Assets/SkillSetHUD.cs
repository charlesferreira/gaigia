using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class SkillSetHUD : MonoBehaviour {

    [SerializeField] private SkillIcon skillIconPrefab;
    [SerializeField] private float radius;

    private List<SkillIcon> skillIcons;

    public void SetUp(SkillSet skillSet) {
        SetUpSkillIcons(skillSet);
    }

    private void SetUpSkillIcons(SkillSet skillSet) {
        var skillCount = skillSet.Skills.Count;
        for (var i = 0; i < skillCount; i++) {
            if (i == skillIcons.Count)
                SpawnSkillIcon();
            skillIcons[i].SetPosition(radius, (float)i / skillCount);
            skillIcons[i].SetActive(true);
        }
        HideUnusedIcons(skillCount);
    }

    private void HideUnusedIcons(int from) {
        for (var i = from; i < skillIcons.Count; i++) {
            skillIcons[i].SetActive(false);
        }
    }

    private void SpawnSkillIcon() {
        skillIcons.Add(Instantiate(skillIconPrefab, transform));
    }

    private void Awake() {
        skillIcons = new List<SkillIcon>();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos() {
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, Vector3.back, radius);
    }
#endif

}
