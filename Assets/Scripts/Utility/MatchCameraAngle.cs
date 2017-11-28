using UnityEngine;

namespace Utility {

    [ExecuteInEditMode]
    public class MatchCameraAngle : MonoBehaviour {

        private void Awake() {
            transform.rotation = Camera.main.transform.rotation;
        }
    }

}