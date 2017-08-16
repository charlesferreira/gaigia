using UnityEngine;

public class SkillRange : Singleton<SkillRange> {

    public void SetUp(Character character) {
        SetActive(character.Team == Team.Player);
        SetParent(character.transform);
        SetSkill(character.GetComponent<SkillSet>().CurrentSkill);
    }

    public void SetSkill(Skill skill) {
        transform.localScale = Vector3.one * skill.Range * 2;
    }

    private void SetActive(bool active) {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(active);
        }
    }

    private void SetParent(Transform parent) {
        transform.SetParent(parent);
        SetPosition(parent.position);
    }

    private void SetPosition(Vector3 position) {
        position.y = transform.position.y;
        transform.position = position;
    }
}
