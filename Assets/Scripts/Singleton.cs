﻿using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

    private static T _instance = null;
    private static object _lock = new object();
    private static bool _applicationIsQuitting = false;

    public static T Instance {
        get {
            if (_applicationIsQuitting)
                return null;

            lock (_lock) {

                if (_instance == null) {
                    _instance = (T)FindObjectOfType<T>();

                    if (_instance == null) {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        DontDestroyOnLoad(singleton);
                    }
                }

                return _instance;
            }
        }
    }

    public void OnDestroy() {
        _applicationIsQuitting = true;
    }
}