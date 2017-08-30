using UnityEngine;

public class SkillTarget : MonoBehaviour {

    SpriteRenderer sr;

    public void SetTarget(Character target) {
        var targetSprite = target.GetComponentInChildren<SpriteRenderer>();

        MoveToParent(targetSprite.transform);
        SetHeight(targetSprite);
    }

    private void MoveToParent(Transform transform) {
        this.transform.SetParent(transform);
        this.transform.localPosition = Vector3.zero;
    }

    private void SetHeight(SpriteRenderer sr) {
        var position = transform.localPosition;
        position.y = sr.GetMaxY();
        transform.localPosition = position;
    }

    public void SetActive(bool active) {
        sr.enabled = active;
    }

    private void Awake() {
        sr = GetComponentInChildren<SpriteRenderer>();
    }
}
