using System.Collections.Generic;
using System.Collections;
using Utility;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(Fading))]
public class DungeonManager : MonoBehaviour {

    private static DungeonManager instance;

    public static DungeonManager Instance { get { return instance; } }

    public Vector3 PlayerPosition { get { return playerPosition; } }

    public SceneField battleScene;
    public SceneField dungeonScene;

    bool isFading = false;
    private Vector3 playerPosition;

    List<string> monstersToRemove = new List<string>();

    public void StartBattleWith(DungeonMonster enemy) {
        print("Lutará contra: " + enemy.name);
        if (isFading)
            return;

        monstersToRemove.Add(enemy.name);

        RememberPlayerPosition();
        StartCoroutine(FadeOut(battleScene, false));
    }

    private void RememberPlayerPosition() {
        playerPosition = GameObject.Find("Player").transform.position;
    }

    public void BackToDungeon() {
        if (isFading)
            return;
        
        StartCoroutine(FadeOut(dungeonScene, true));
    }

    private IEnumerator FadeOut(SceneField nextScene, bool enablePlayerAfter) {
        isFading = true;

        var fading = GetComponent<Fading>();
        fading.BeginFade(Fading.Direction.FadeOut);
        yield return new WaitForSeconds(fading.FadingDuration);

        SceneManager.LoadScene(nextScene);

        isFading = false;
    }

    private void Awake() {
        print("Removendo inimigos: " + monstersToRemove);
        for (int i = 0; i < monstersToRemove.Count; i++) {
            GameObject.Find(monstersToRemove[i]).gameObject.SetActive(false);
        }

        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        RememberPlayerPosition();
    }
}