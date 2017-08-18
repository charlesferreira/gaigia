using UnityEngine;

public class CameraPerspective2D : MonoBehaviour {

    private void Awake() {
        GetComponent<Camera>().transparencySortMode = TransparencySortMode.Orthographic;
    }
}
