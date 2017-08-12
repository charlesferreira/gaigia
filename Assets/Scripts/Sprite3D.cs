using UnityEngine;

[ExecuteInEditMode]
public class Sprite3D : MonoBehaviour {

    private void LateUpdate() {
        transform.rotation = Camera.main.transform.rotation;
    }
}
