using System.Collections.Generic;
using System.Collections;
using Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Fading))]
public class DungeonManager : Singleton<DungeonManager> {

    public Vector3 PlayerPosition { get { return playerPosition; } }

    public SceneField battleScene;
    public SceneField dungeonScene;

    bool isFading = false;
    private Vector3 playerPosition;

    [HideInInspector]
    public List<string> monstersToRemove = new List<string>();

    public void StartBattleWith(DungeonMonster enemy) {
        if (isFading || monstersToRemove.Contains(enemy.name))
            return;

        Jukebox.Instance.Battle();
        GameObject.Find("Player").GetComponent<DungeonCharacter>().enabled = false;

        CombatInfo.Instance.EnemyParty = enemy.party;
        monstersToRemove.Add(enemy.name);

        RememberPlayerPosition();
        StartCoroutine(FadeOut(battleScene, false));
    }

    private void RememberPlayerPosition() {
        var player = GameObject.Find("Player");
        if (player) {
            playerPosition = GameObject.Find("Player").transform.position;
        }
    }

    public void BackToDungeon() {
        if (isFading)
            return;

        Jukebox.Instance.Dungeon();
        StartCoroutine(FadeOut(dungeonScene, true));
    }

    private IEnumerator FadeOut(SceneField nextScene, bool enablePlayerAfter) {
        isFading = true;

        var fading = FindObjectOfType<Fading>();
        fading.BeginFade(Fading.Direction.FadeOut);
        yield return new WaitForSeconds(fading.FadingDuration);

        SceneManager.LoadScene(nextScene);

        isFading = false;
    }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        RememberPlayerPosition();
        Jukebox.Instance.Dungeon();
    }
}