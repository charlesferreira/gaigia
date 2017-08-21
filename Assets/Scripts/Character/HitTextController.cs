using UnityEngine;

public class HitTextController : MonoBehaviour {

    [SerializeField] private Animator animator;

    private TextMesh damageText;

    public void SetText(string text) {
        damageText.text = text;
    }

    private void Awake() {
        damageText = animator.GetComponent<TextMesh>();
    }

    private void Start() {
        var animationClips = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, animationClips[0].clip.length);
    }
}
