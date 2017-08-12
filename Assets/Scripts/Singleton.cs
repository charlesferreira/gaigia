using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

    private static T instance = null;
    private static object @lock = new object();

    public static T Instance {
        get {
            lock (@lock) {
                if (instance == null) {
                    instance = FindObjectOfType<T>();

                    if (instance == null) {
                        GameObject singleton = new GameObject();
                        instance = singleton.AddComponent<T>();
                        DontDestroyOnLoad(singleton);
                    }
                }

                return instance;
            }
        }
    }
}