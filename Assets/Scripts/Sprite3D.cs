using UnityEngine;

[ExecuteInEditMode]
public class Sprite3D : MonoBehaviour {

    private void Update() {
        transform.rotation = Camera.main.transform.rotation;
    }
}
