using UnityEngine;

public class MovementArea : MonoBehaviour {

    public const int MaxMovementPoints = 5;

    [SerializeField] private SpriteRenderer circlePrefab;
    [SerializeField] private Transform spritesContainer;
    [SerializeField] private Transform colliders;
    [SerializeField] private Color color;
    [Range(0, 1)]
    [SerializeField] private float minAlpha;
    [Range(0, 1)]
    [SerializeField] private float maxAlpha;

    public void SetUp(Character character) {
        SetActive(character.Team == Team.Player);
        SetPosition(character.transform.position);
        character.Movement.SetCenter();
    }

    private void SetActive(bool active) {
        spritesContainer.gameObject.SetActive(active);
    }

    private void SetPosition(Vector3 position) {
        position.y = transform.position.y;
        transform.position = position;
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
