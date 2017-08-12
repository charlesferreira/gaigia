using UnityEngine;

[ExecuteInEditMode]
public class BattleCamera : MonoBehaviour {

    [SerializeField] private Transform target;
    [Range(0, 10)]
    [SerializeField]
    private float panDistance;
    [Range(0, 1)]
    [SerializeField]
    private float damping;
    [Range(1, 1000)]
    [SerializeField]
    private float speed;

    Vector3 panOffset;

    public void SetUp(Transform target) {
        this.target = target;
    }

    private void LateUpdate() {
        if (target == null) return;

        UpdateOffset();
        UpdatePosition();
    }

    private void UpdateOffset() {
        panOffset.Set(Input.GetAxis("Right Horizontal"), 0, Input.GetAxis("Right Vertical"));
    }

    private void UpdatePosition() {
        var distance = target.position + (panOffset * panDistance) - transform.position;
        transform.position += distance * (1f - damping) * speed * Time.deltaTime;
    }
}
