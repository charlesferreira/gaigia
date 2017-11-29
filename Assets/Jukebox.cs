using UnityEngine;

public class Jukebox : Singleton<Jukebox> {

    [SerializeField] AudioSource dungeonTheme;
    [SerializeField] AudioSource battleTheme;
    [SerializeField] AudioSource victoryTheme;

    public void Dungeon() {
        dungeonTheme.Play();
        battleTheme.Stop();
        victoryTheme.Stop();
    }

    public void Battle() {
        dungeonTheme.Stop();
        battleTheme.Play();
        victoryTheme.Stop();
    }

    public void Victory() {
        dungeonTheme.Stop();
        battleTheme.Stop();
        victoryTheme.Play();
    }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

}
