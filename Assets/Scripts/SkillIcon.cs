using UnityEngine;
using UnityEngine.UI;

public class SkillIcon : MonoBehaviour {

    [SerializeField] private Image icon;

    public void SetSkill(Skill skill) {
        icon.overrideSprite = skill.Icon;
    }

    public void SetPosition(float radius, float angleRatio) {
        transform.rotation = Quaternion.AngleAxis(360 * angleRatio, Vector3.back);
        icon.transform.position = transform.position + transform.up * radius;
    }

    public void SetActive(bool active) {
        gameObject.SetActive(active);
    }
}
