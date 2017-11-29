using UnityEngine;

public class CombatInfo : MonoBehaviour {

    private static CombatInfo instance;

    public static CombatInfo Instance {
        get {
            if (instance == null)
                instance = FindObjectOfType<CombatInfo>();

            return instance;
        }
    }

    [SerializeField] private Party playerParty;

    public Party EnemyParty { get; set; }
    public Character[] PlayerCharacters { get; private set; }

    public void ResetPlayerParty() {
        PlayerCharacters = playerParty.CreateCharacters();
    }

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
