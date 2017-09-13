using System;
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

    public void CreatePortraits(BattleManager bm) {
        var lastPosition = transform.position + Vector3.left * avatarWidth * (bm.Characters.Count - 1);
        foreach (var character in bm.Characters) {
            var avatar = Instantiate(avatarPrefab, transform);
            avatars.Add(avatar);
            avatar.SetUp(character);
            avatar.SetActive(bm.Character);
            avatar.transform.position = lastPosition;
            lastPosition += Vector3.right * avatarWidth;
        }
    }

    public void MarkDead(int i) {
        avatars[i].MarkDead();
    }

    private void Awake() {
        avatars = new List<ActionSequenceAvatar>();
    }
}
