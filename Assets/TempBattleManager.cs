using System.Collections.Generic;
using UnityEngine;

public class TempBattleManager : MonoBehaviour {

    [SerializeField] private List<Character> characters;
    [SerializeField] private MovementArea movementArea;
    [SerializeField] private SkillRange skillRange;
    [SerializeField] private BattleCamera battleCamera;
    [SerializeField] private SkillSetHUD skillSetHUD;

    int activeCharacterIndex;
    Character ActiveCharacter { get { return characters[activeCharacterIndex]; } }

    private void Start() {
        activeCharacterIndex = -1;
        SelectNextCharacter();
    }

    private void Update() {
        if (PlayerInput.Confirm) {
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
            characters[i].SetActive(i == activeCharacterIndex);
        }
        movementArea.SetUp(ActiveCharacter);
        skillRange.SetUp(ActiveCharacter);
        skillSetHUD.SetUp(ActiveCharacter.GetComponent<SkillSet>());
        battleCamera.SetUp(ActiveCharacter.transform);
    }
}
