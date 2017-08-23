using UnityEngine;
using UnityEngine.UI;

public class ActionSequenceAvatar : MonoBehaviour {

    [SerializeField] private Image avatar;
    [SerializeField] private Image frame;
    [SerializeField] private Image turnLabel;
    [SerializeField] private Color idleColor;
    [SerializeField] private Color activeColor;

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
        var active = activeCharacter == character;
        turnLabel.gameObject.SetActive(active);
        Color = active ? activeColor : idleColor;
    }

    private void Awake() {
        Color = idleColor;
    }
}
