using System;
using System.Collections.Generic;
using UnityEngine;

public class TempBattleManager : MonoBehaviour {

    public List<Character> characters;

    int activeCharacterIndex;
    Character ActiveCharacter { get { return characters[activeCharacterIndex]; } }

    private void Start() {
        activeCharacterIndex = -1;
        SelectNextCharacter();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            SelectNextCharacter();
        }
    }

    private void SelectNextCharacter() {
        activeCharacterIndex += 1;
        activeCharacterIndex %= characters.Count;
        ActivateCurrentCharacter();
    }

    private void ActivateCurrentCharacter() {
        for (var i = 0; i < characters.Count; i++) {
            characters[i].GetComponent<CharacterMovement>().SetActive(i == activeCharacterIndex);
        }
    }
}
