﻿using UnityEngine;

public class MovementArea : MonoBehaviour {

    public void SetUp(Character character) {
        SetActive(character.TeamFlag == TeamFlag.Player);
        SetPosition(character.transform.position);
    }

    private void SetActive(bool active) {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(active);
        }
    }

    private void SetPosition(Vector3 position) {
        position.y = transform.position.y;
        transform.position = position;
    }
}
