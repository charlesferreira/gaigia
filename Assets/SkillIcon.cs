using UnityEngine;

public class SkillIcon : MonoBehaviour {

    [SerializeField] private Transform icon;

    public void SetActive(bool active) {
        gameObject.SetActive(active);
    }

    public void SetPosition(float radius, float angleRatio) {
        transform.rotation = Quaternion.AngleAxis(360 * angleRatio, Vector3.forward);
        icon.position = transform.position + transform.up * radius;
    }
}
