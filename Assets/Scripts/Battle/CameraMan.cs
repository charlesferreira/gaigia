﻿using UnityEngine;

[ExecuteInEditMode]
public class CameraMan : Singleton<CameraMan> {

    [SerializeField] private Transform target;
    [Range(0, 10)]
    [SerializeField] private float panDistance;
    [Range(0, 1)]
    [SerializeField] private float damping;
    [Range(1, 1000)]
    [SerializeField] private float speed;

    private Vector3 panOffset;

    protected CameraMan() {}

    public void SetTarget(Transform target) {
        this.target = target;
    }

    public void Pan(float x, float z) {
        panOffset.Set(x, 0, z);
    }

    private void LateUpdate() {
        if (target == null) return;
        
        UpdatePosition();
    }

    private void UpdatePosition() {
        var distance = target.position + (panOffset * panDistance) - transform.position;
        transform.position += distance * (1f - damping) * speed * Time.smoothDeltaTime;
    }
}
