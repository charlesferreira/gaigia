using UnityEngine;

public class CombatInfo : Singleton<CombatInfo> {

    [SerializeField] private Party playerParty;

    public Party EnemyParty { get; set; }
    public Character[] PlayerCharacters { get; private set; }

    public void ResetPlayerPositions() {
        for (int i = 0; i < PlayerCharacters.Length; i++)
            PlayerCharacters[i].transform.position = playerParty.Members[i].spawnPoint;
    }

    private void Awake() {
        PlayerCharacters = playerParty.CreateCharacters();
    }
}
