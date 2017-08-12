using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class SkillSetHUD : Singleton<SkillSetHUD> {

    [SerializeField] private SkillIcon skillIconPrefab;
    [SerializeField] private float radius;
    [Range(0, 1)]
    [SerializeField] private float rotationDamping;
    [Range(1, 100)]
    [SerializeField] private float rotationSpeed;

    private List<SkillIcon> skillIcons;
    private int currentSkillIconIndex;
    private float rotationAngleFrom;
    private float rotationAngleTo;
    private SkillSet skillSet;

    private int CurrentSkillIconIndex {
        get { return currentSkillIconIndex; }
        set {
            currentSkillIconIndex = value % skillSet.Count;
            rotationAngleFrom = transform.rotation.eulerAngles.z;
            rotationAngleTo = 360 * currentSkillIconIndex / skillSet.Count;
        }
    }

    protected SkillSetHUD() { }

    public void SelectNextSkill() {
        CurrentSkillIconIndex++;
    }

    public void SelectPreviousSkill() {
        CurrentSkillIconIndex--;
    }

    public void SetUp(SkillSet skillSet) {
        this.skillSet = skillSet;
        SetUpSkillIcons();
        ResetRotation();
    }

    private void ResetRotation() {
        currentSkillIconIndex = skillSet.CurrentSkillIndex;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationAngleTo));
    }

    private void SetUpSkillIcons() {
        for (var i = 0; i < skillSet.Count; i++) {
            SpawnSkillIcon(i);
            skillIcons[i].SetPosition(radius, (float)i / skillSet.Count);
            skillIcons[i].SetActive(true);
        }
        HideUnusedIcons();
    }

    private void HideUnusedIcons() {
        for (var i = skillSet.Skills.Count; i < skillIcons.Count; i++) {
            skillIcons[i].SetActive(false);
        }
    }

    private void SpawnSkillIcon(int index) {
        if (index < skillIcons.Count) return;

        skillIcons.Add(Instantiate(skillIconPrefab, transform));
    }

    private void Awake() {
        skillIcons = new List<SkillIcon>();
    }

    private void LateUpdate() {
        if (skillSet == null) return;

        var deltaAngle = Mathf.DeltaAngle(rotationAngleFrom, rotationAngleTo);
        var rotationAngle = rotationAngleFrom + deltaAngle * (1f - rotationDamping) * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));
        rotationAngleFrom = transform.rotation.eulerAngles.z;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos() {
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, Vector3.back, radius);
    }
#endif

}
