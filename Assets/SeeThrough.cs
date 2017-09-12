using UnityEngine;

public class SeeThrough : MonoBehaviour {


    private void OnTriggerEnter(Collider other) {
        other.gameObject.SetActive(false);
    }
}
