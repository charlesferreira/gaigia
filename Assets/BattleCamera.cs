using UnityEngine;

[ExecuteInEditMode]
public class BattleCamera : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [Range(0, 1)]
    [SerializeField] private float damping;

    new Camera camera;

    public void SetUp(Transform target) {
        this.target = target;
    }

    private void Awake() {
        camera = GetComponent<Camera>();
    }

    private void FixedUpdate() {
        if (target == null) return;

        var distance = target.position + offset - transform.position;

        transform.position += distance * (1f - damping);
    }
}
