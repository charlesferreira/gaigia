using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SkillSetHUD : Singleton<SkillSetHUD> {

    [SerializeField] private Transform container;
    [SerializeField] private SkillIcon skillIconPrefab;
    [SerializeField] private Text skillName;
    [SerializeField] private float radius;
    [Range(0, 1)]
    [SerializeField] private float rotationDamping;
    [Range(1, 100)]
    [SerializeField] private float rotationSpeed;

    private List<SkillIcon> skillIcons;
    private float RotationAngleFrom { get { return container.rotation.eulerAngles.z; } }
    private float RotationAngleTo { get { return 360 * skillSet.CurrentSkillIndex / skillSet.Count; } }
    private SkillSet skillSet;

    protected SkillSetHUD() { }

    public void SetUp(Character character) {
        //SetActive(character.Team == Team.Player);
        skillSet = character.GetComponent<SkillSet>();
        ResetRotation();
        SetUpSkillIcons();
    }

    private void SetActive(bool active) {
        gameObject.SetActive(active);
    }

    private void ResetRotation() {
        container.rotation = Quaternion.Euler(new Vector3(0, 0, RotationAngleTo));
    }

    private void SetUpSkillIcons() {
        for (var i = 0; i < skillSet.Count; i++) {
            SpawnSkillIcon(i);
            skillIcons[i].SetSkill(skillSet[i]);
            skillIcons[i].SetPosition(radius, (float)(i - skillSet.CurrentSkillIndex) / skillSet.Count);
            skillIcons[i].SetActive(true);
        }
        HideUnusedIcons();
    }

    private void SpawnSkillIcon(int index) {
        if (index < skillIcons.Count) return;

        skillIcons.Add(Instantiate(skillIconPrefab, container));
    }

    private void HideUnusedIcons() {
        for (var i = skillSet.Skills.Count; i < skillIcons.Count; i++) {
            skillIcons[i].SetActive(false);
        }
    }

    private void Awake() {
        skillIcons = new List<SkillIcon>();
    }

    private void LateUpdate() {
        if (skillSet == null) return;

        var deltaAngle = Mathf.DeltaAngle(RotationAngleFrom, RotationAngleTo);
        var rotationAngle = RotationAngleFrom + deltaAngle * (1f - rotationDamping) * rotationSpeed * Time.deltaTime;
        container.rotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));
        skillName.text = skillSet.CurrentSkill.Name;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos() {
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(container.position, Vector3.back, radius);
    }
#endif

}
