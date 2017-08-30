using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour {

    public const float MaxMovementSpeed = 30;
    public const int MovementPerUnit = 3;

    private static float animationSpeedMin = 1.0f;
    private static float animationSpeedMax = 1.8f;
    private static float animationSpeedFactor = 2f;
    private static float movementSpeedFactor = 0.425f;

    Rigidbody rb;
    Character character;
    
    public int Cost { get { return Mathf.FloorToInt(transform.position.Distance(Center) * MaxMovementPoints / MaxDistance); } }
    
    private Vector2 Input { get; set; }
    private Vector3 Center { get; set; }
    private float MaxDistance { get { return (float) character.Stats.Movement / MovementPerUnit; } }
    private float MovementSpeed { get { return movementSpeedFactor * Mathf.Min(MaxMovementSpeed, character.Stats.Movement); } }
    private int MaxMovementPoints { get { return MovementArea.MaxMovementPoints; } }

    public void SetActive(bool active) {
        Stop();
        enabled = active;
        rb.isKinematic = !active;
    }

    public void SetCenter() {
        Center = transform.position;
    }

    public void Walk(Vector2 input) {
        if (input == Vector2.zero) {
            Stop();
            return;
        }

        Input = input;
        character.Animation.Face(input);
        character.Animation.SetState(CharacterAnimationState.Walking);
        character.Animation.SetSpeed(Mathf.Clamp(input.magnitude * animationSpeedFactor, animationSpeedMin, animationSpeedMax));
    }

    public void Stop() {
        Input = Vector2.zero;
        character.Animation.SetState(CharacterAnimationState.Idle);
    }

    private void Awake() {
        rb = GetComponentInChildren<Rigidbody>();
        character = GetComponentInChildren<Character>();
    }

    private void FixedUpdate() {
        transform.Translate(new Vector3(Input.x, 0, Input.y).normalized * MovementSpeed * Time.fixedDeltaTime);
    }
}
