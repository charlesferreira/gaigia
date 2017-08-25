using UnityEngine;

public class Loot : MonoBehaviour {
    
    [SerializeField] private SpriteRenderer sprite;

    private bool Collected { get; set; }

    public void OnApproach() {
        if (Collected) return;

        sprite.color = Color.yellow;
    }

    public void OnLeave() {
        sprite.color = Color.white;
    }

    public void Collect() {
        Collected = true;
        OnLeave();
    }
}
