using UnityEngine;

public class SeeThrough : MonoBehaviour {

    public SpriteRenderer sr;

    Transform cam;
    float fadeMinDistance = -17.5f;
    float fadeAmount = 1.5f;

    private void Start() {
        cam = FindObjectOfType<Camera>().transform;
    }

    private void OnBecameInvisible() {
        enabled = false;
    }

    private void OnBecameVisible() {
        enabled = true;
    }

    private void LateUpdate() {
        var distance = cam.position.z - transform.position.z;
        if (distance > fadeMinDistance) {
            var tint = Mathf.Max(0.33f, fadeAmount / (distance - fadeMinDistance));
            sr.color = Color.white * tint;
        }
        else {
            sr.color = Color.white;
        }
    }
}
