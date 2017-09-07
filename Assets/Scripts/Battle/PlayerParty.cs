using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : Singleton<PlayerParty> {

    [SerializeField] private List<CharacterPreset> presets;

    public List<Character> Characters { get; private set; }

    private void Awake() {
        Characters = new List<Character>();
        foreach (var preset in presets) {
            Characters.Add(Character.CreateInstance(preset));
        }
    }

}
