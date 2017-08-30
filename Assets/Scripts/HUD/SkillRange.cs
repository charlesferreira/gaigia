using UnityEngine;

public class SkillRange : MonoBehaviour {

    [SerializeField] private SpriteRenderer circle;

    [Header("Debug")]
    [SerializeField] private bool alwaysActive;

    public void SetUp(Character character) {
        SetActive(character.Team == Team.Player);
        SetParent(character.transform);
        SetRange(character.Skill.GetRange(character));
    }

    public void SetRange(float range) {
        transform.localScale = Vector3.one * range * 2;
    }

    public void UpdateColor(bool hasEnoughAP, bool hasValidTarget) {
        circle.color = hasEnoughAP && hasValidTarget
            ? Color.white
            : hasEnoughAP
                ? Color.yellow
                : Color.red;
    }

    private void SetActive(bool active) {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(active || alwaysActive);
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
