using UnityEngine;

[ExecuteInEditMode]
public class Billboard : MonoBehaviour {

    private void Update() {
        transform.LookAt(Camera.main.transform.position, Camera.main.transform.up);

    }
}
