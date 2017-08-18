using System.Collections.Generic;
using UnityEngine;

public class ActionSequence : Singleton<ActionSequence> {

    [SerializeField] private Color activeColor;
    [SerializeField] private Color idleColor;
    [SerializeField] private ActionSequenceAvatar avatarPrefab;
    [Range(1, 200)]
    [SerializeField] private float avatarWidth;

    private List<ActionSequenceAvatar> avatars;

    public Color IdleColor { get { return idleColor; } }
    public Color ActiveColor { get { return activeColor; } }

    protected ActionSequence() { }

    public void SetUp(Character activeCharacter) {
        foreach (var avatar in avatars) {
            avatar.SetActive(activeCharacter);
        }
    }

    private void Awake() {
        avatars = new List<ActionSequenceAvatar>();
        CreatePortraits();
    }

    private void CreatePortraits() {
        var characters = BattleManager.Instance.Characters;
        var lastPosition = transform.position + Vector3.left * avatarWidth * (characters.Count - 1);
        foreach (var character in characters) {
            var avatar = Instantiate(avatarPrefab, transform);
            avatars.Add(avatar);
            avatar.SetUp(character);
            avatar.transform.position = lastPosition;
            lastPosition += Vector3.right * avatarWidth;
        }
    }
}
