using UnityEngine;

public class MovementArea : MonoBehaviour {

    public const int MaxMovementPoints = 5;
    public const int BaseCharacterMovement = 12;

    [SerializeField] private SpriteRenderer circlePrefab;
    [SerializeField] private Transform spritesContainer;
    [SerializeField] private Transform colliders;
    [SerializeField] private Color color;
    [Range(0, 1)]
    [SerializeField] private float minAlpha;
    [Range(0, 1)]
    [SerializeField] private float maxAlpha;

    [Header("Debug")]
    [SerializeField] private bool alwaysActive;

    public void SetUp(Character character) {
        SetActive(character.Team == Team.Player);
        SetPosition(character.transform.position);
        SetScale(character.Stats.Movement);
        character.Movement.SetCenter();
    }

    private void SetActive(bool active) {
        spritesContainer.gameObject.SetActive(active || alwaysActive);
    }

    private void SetPosition(Vector3 position) {
        position.y = transform.position.y;
        transform.position = position;
    }

    private void SetScale(int movement) {
        transform.localScale = Vector3.one * movement / BaseCharacterMovement;
    }

    private void Awake() {
        SpriteRenderer circle;
        for (var i = 0; i <= MaxMovementPoints; i++) {
            circle = Instantiate(circlePrefab, spritesContainer);
            circle.transform.localScale *= i + 1;
            color.a =  minAlpha + (maxAlpha - minAlpha) * (1f - (float) i / (MaxMovementPoints));
            circle.color = color;
        }
        colliders.localScale *= 1 + MaxMovementPoints;
    }
}
