using System.Collections.Generic;
using UnityEngine;

public class EnemyParty : MonoBehaviour {

    [SerializeField] private Character prefab;
    [SerializeField] private CharacterPreset preset;
    [SerializeField] private Transform[] spawnPoints;

    public List<Character> Characters { get; private set; }

    private void Awake() {
        Characters = new List<Character>();
        for (int i = 0; i < spawnPoints.Length; i++) {
            var mob = Character.Instantiate(prefab, preset);
            mob.transform.position = spawnPoints[i].position;
            Characters.Add(mob);
        }
    }

}