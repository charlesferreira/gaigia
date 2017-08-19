﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour {

    private static float animationSpeedMin = 1.0f;
    private static float animationSpeedMax = 1.8f;
    private static float animationSpeedFactor = 2f;
    private static float movementSpeedFactor = 0.35f;

    Rigidbody rb;
    Character character;
    CharacterAnimations anim;
    Vector2 input;

    private float MovementSpeed {
        get {
            return Mathf.Min(StatsSheet.MaxMovementSpeed, character.Stats.Movement) * movementSpeedFactor;
        }
    }

    public void SetActive(bool active) {
        Stop();
        enabled = active;
        rb.isKinematic = !active;
    }

    public void Walk(Vector2 input) {
        if (input == Vector2.zero) {
            Stop();
            return;
        }

        this.input = input;
        anim.Face(input);
        anim.SetState(CharacterAnimationState.Walking);
        anim.SetSpeed(Mathf.Clamp(input.magnitude * animationSpeedFactor, animationSpeedMin, animationSpeedMax));
    }

    public void Stop() {
        input = Vector2.zero;
        anim.SetState(CharacterAnimationState.Idle);
    }

    private void Awake() {
        rb = GetComponentInChildren<Rigidbody>();
        character = GetComponentInChildren<Character>();
        anim = GetComponentInChildren<CharacterAnimations>();
    }

    private void FixedUpdate() {
        transform.Translate(new Vector3(input.x, 0, input.y) * MovementSpeed * Time.fixedDeltaTime);
    }
}