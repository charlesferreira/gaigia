using System.Collections.Generic;
using UnityEngine;

public class ActionSequence : MonoBehaviour {
    
    [SerializeField] private ActionSequenceAvatar avatarPrefab;
    [Range(1, 200)]
    [SerializeField] private float avatarWidth;

    private List<ActionSequenceAvatar> avatars;

    public void SetUp(Character activeCharacter) {
        foreach (var avatar in avatars) {
            avatar.SetActive(activeCharacter);
        }
    }

    public void CreatePortraits(IList<Character> characters) {
        var lastPosition = transform.position + Vector3.left * avatarWidth * (characters.Count - 1);
        foreach (var character in characters) {
            var avatar = Instantiate(avatarPrefab, transform);
            avatars.Add(avatar);
            avatar.SetUp(character);
            avatar.transform.position = lastPosition;
            lastPosition += Vector3.right * avatarWidth;
        }
    }

    private void Awake() {
        avatars = new List<ActionSequenceAvatar>();
    }
}
