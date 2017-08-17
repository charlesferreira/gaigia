using UnityEngine;

[ExecuteInEditMode]
public class Sprite3D : MonoBehaviour {

    private void Awake() {
        transform.rotation = Camera.main.transform.rotation;
    }
}
