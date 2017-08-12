using UnityEngine;

[ExecuteInEditMode]
public class Billboard2D : MonoBehaviour {

    private void LateUpdate() {
        transform.right = Camera.main.transform.right;
    }

}
