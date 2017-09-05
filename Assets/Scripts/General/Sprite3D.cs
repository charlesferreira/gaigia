using UnityEngine;

[ExecuteInEditMode]
public class Sprite3D : MonoBehaviour {

    private void OnBecameVisible() {
        enabled = true;
    }

    private void OnBecameInvisible() {
        enabled = false;
    }

    private void Update() {
        transform.rotation = Camera.main.transform.rotation;
    }
}
