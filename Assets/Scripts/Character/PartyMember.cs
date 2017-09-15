using System;
using UnityEngine;

[Serializable]
public struct PartyMember {
    public CharacterPreset preset;
    public Vector3 spawnPoint;

    public Character Instantiate(Team team) {
        return preset.Instantiate(team, spawnPoint);
    }
}