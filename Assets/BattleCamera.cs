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

    Vector3 panOffset;

    public void SetUp(Transform target) {
        this.target = target;
    }

    private void FixedUpdate() {
        if (target == null) return;

        UpdateOffset();
        UpdatePosition();
    }

    private void UpdateOffset() {
        panOffset.Set(Input.GetAxis("RightHorizontal"), 0, Input.GetAxis("RightVertical"));
    }

    private void UpdatePosition() {
        var distance = target.position + (panOffset * panDistance) - transform.position;
        transform.position += distance * (1f - damping);
    }
}
