using UnityEngine;

public class HitTextController : MonoBehaviour {

    public enum Type {
        Damage, Healing
    }

    [SerializeField] private Animator animator;
    [SerializeField] private Color damageColor;
    [SerializeField] private Color healingColor;

    private TextMesh damageText;

    public void SetText(string text, Type type) {
        damageText.text = text;
        damageText.color = type == Type.Damage ? damageColor : healingColor;
    }

    public void SetY(float y) {
        var position = transform.localPosition;
        position.y += y;
        transform.localPosition = position;
    }

    public void FixXScale() {
        var scale = transform.localScale;
        scale.x *= Mathf.Sign(scale.x);
        transform.localScale = scale;
    }

    private void Awake() {
        damageText = animator.GetComponent<TextMesh>();
    }

    private void Start() {
        var animationClips = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, animationClips[0].clip.length);
    }
}
