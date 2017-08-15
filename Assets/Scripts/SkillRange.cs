using UnityEngine;

public class SkillRange : Singleton<SkillRange> {


    public void SetUp(Character character) {
        SetActive(character.TeamFlag == TeamFlag.Player);
        SetParent(character.transform);
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
