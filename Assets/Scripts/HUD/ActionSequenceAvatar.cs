using UnityEngine;
using UnityEngine.UI;

public class ActionSequenceAvatar : MonoBehaviour {

    [SerializeField] private Image avatar;
    [SerializeField] private Image frame;
    [SerializeField] private Image turnLabel;
    private Character character;

    private Color Color {
        set {
            frame.color = turnLabel.color = value;
        }
    }

    public void SetUp(Character character) {
        this.character = character;
        avatar.overrideSprite = character.Avatar;
    }

    internal void SetActive(Character activeCharacter) {
        turnLabel.gameObject.SetActive(activeCharacter == character);
    }

    private void Awake() {
        Color = ActionSequence.Instance.NeutralColor;
    }
}
