using UnityEngine;

[ExecuteInEditMode]
public class Billboard2D : MonoBehaviour {

    private void Update() {
        transform.right = Camera.main.transform.right;
    }

}
