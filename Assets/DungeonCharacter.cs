using UnityEngine;

public class DungeonCharacter : MonoBehaviour {

    public float animationSpeedMin = 1.0f;
    public float animationSpeedMax = 1.8f;
    public float animationSpeedFactor = 2f;

    [Header("Character")]
    public float movementSpeed = 10;

    CharacterAnimations charAnim;

    private Vector2 Input { get; set; }
    private CharacterAnimations Animation { get { return charAnim; } }

    public void Walk(Vector2 input) {
        if (input == Vector2.zero) {
            Stop();
            return;
        }

        Input = input;
        Animation.Face(input);
        Animation.SetState(CharacterAnimationState.Walking);
        Animation.SetSpeed(Mathf.Clamp(input.magnitude * animationSpeedFactor, animationSpeedMin, animationSpeedMax));
    }

    public void Stop() {
        Input = Vector2.zero;
        Animation.SetState(CharacterAnimationState.Idle);
    }

    protected virtual Vector2 GetInput() {
        return new Vector2(PlayerInput.LeftStickHorizontal, PlayerInput.LeftStickVertical);
    }

    protected virtual void Awake() {
        charAnim = GetComponentInChildren<CharacterAnimations>();
    }

    private void Start() {
        if (name == "Player")
            transform.position = DungeonManager.Instance.PlayerPosition;
    }

    void FixedUpdate() {
        transform.Translate(new Vector3(Input.x, 0, Input.y).normalized * movementSpeed * Time.fixedDeltaTime);
    }

    void Update() {
        Walk(GetInput());
    }
}
