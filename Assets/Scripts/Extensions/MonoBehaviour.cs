using UnityEngine;

public static class MonoBehaviourExtension {

    public static float Distance(this MonoBehaviour self, MonoBehaviour other) {
        return self.transform.position.Distance(other.transform.position);
    }

    public static float SqrDistance(this MonoBehaviour self, MonoBehaviour other) {
        return self.transform.position.SqrDistance(other.transform.position);
    }
}
