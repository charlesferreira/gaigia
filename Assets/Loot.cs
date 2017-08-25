using UnityEngine;

public class Loot : MonoBehaviour {

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Item item;
    [Range(1, 99)]
    [SerializeField] private int quantity = 1;

    private bool Collected { get; set; }

    public void OnApproach() {
        if (Collected) return;

        sprite.color = Color.yellow;
    }

    public void OnLeave() {
        sprite.color = Color.white;
    }

    public void Collect() {
        if (Collected) return;

        Inventory.Instance.Add(item, quantity);
        Collected = true;
        OnLeave();
    }
}
