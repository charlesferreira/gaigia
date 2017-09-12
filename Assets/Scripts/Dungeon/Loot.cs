using System.Collections;
using UnityEngine;

public class Loot : MonoBehaviour {

    [SerializeField] private SpriteRenderer containerSprite;
    [SerializeField] private Animator iconAnimator;
    [SerializeField] private Item item;
    [Range(1, 99)]
    [SerializeField] private int quantity = 1;

    private SpriteRenderer iconSprite;

    private bool Collected { get; set; }

    public void OnApproach() {
        if (Collected) return;

        containerSprite.color = Color.yellow;
    }

    public void OnLeave() {
        containerSprite.color = Color.white;
    }

    public void Collect() {
        if (Collected) return;

        Collected = true;
        StartCoroutine(SpawnIcon());
        Inventory.Instance.Add(item, quantity);
        OnLeave();
    }

    private IEnumerator SpawnIcon() {
        iconSprite.enabled = true;
        iconAnimator.enabled = true;
        var clipInfo = iconAnimator.GetCurrentAnimatorClipInfo(0);
        yield return new WaitForSeconds(clipInfo[0].clip.length);

        Destroy(iconAnimator.gameObject);
    }

    private void Awake() {
        iconSprite = iconAnimator.GetComponent<SpriteRenderer>();
        iconSprite.sprite = item.Icon;
        iconSprite.enabled = false;
        iconAnimator.enabled = false;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos() {
        iconSprite.sprite = item.Icon;
    }
#endif

}
