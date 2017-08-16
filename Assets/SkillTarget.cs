using UnityEngine;

public class SkillTarget : Singleton<SkillTarget> {

    SpriteRenderer sr;

    public void SetTarget(Character target) {
        var targetSprite = target.GetComponentInChildren<SpriteRenderer>();
        transform.position = targetSprite.transform.position;
        transform.rotation = targetSprite.transform.rotation;
    }

    public void SetActive(bool active) {
        sr.enabled = active;
    }

    private void Awake() {
        sr = GetComponentInChildren<SpriteRenderer>();
    }
}
