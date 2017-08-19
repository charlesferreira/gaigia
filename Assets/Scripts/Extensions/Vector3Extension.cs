using UnityEngine;

public static class Vector3Extension {

    public static float SqrDistance(this Vector3 self, Vector3 other) {
        return (self - other).sqrMagnitude;
    }

    public static float Distance(this Vector3 self, Vector3 other) {
        return (self - other).magnitude;
    }
}
