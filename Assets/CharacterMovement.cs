using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Character))]
public class CharacterMovement : MonoBehaviour {

    private static float animationSpeedMin = 1.0f;
    private static float animationSpeedMax = 1.8f;
    private static float animationSpeedFactor = 2f;
    private static float movementSpeedFactor = 0.35f;

    Rigidbody rb;
    Character character;
    CharacterAnimations anim;

    private float MovementSpeed {
        get {
            return Mathf.Min(StatsSheet.MaxMovementSpeed, character.Stats.Movement) * movementSpeedFactor;
        }
    }

    private void Awake() {
        rb = GetComponentInChildren<Rigidbody>();
        character = GetComponentInChildren<Character>();
        anim = GetComponentInChildren<CharacterAnimations>();
    }

    private void FixedUpdate() {
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (input != Vector2.zero)
            Walk(input);
        else
            Stop();
    }

    public void SetActive(bool active) {
        Stop();
        enabled = active;
        rb.isKinematic = !active;
    }

    private void Walk(Vector2 input) {
        // move
        transform.Translate(new Vector3(input.x, 0, input.y) * MovementSpeed * Time.fixedDeltaTime);

        // update animation
        anim.Face(input);
        anim.SetState(CharacterAnimationState.Walking);
        anim.SetSpeed(Mathf.Clamp(input.magnitude * animationSpeedFactor, animationSpeedMin, animationSpeedMax));
    }

    private void Stop() {
        anim.SetState(CharacterAnimationState.Idle);
    }
}
