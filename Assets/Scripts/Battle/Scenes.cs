using UnityEngine.SceneManagement;

public static class Scenes {

    public const string Dungeon = "Dungeon";
    public const string Battle = "Battle";

    public static void LoadSingle(string scene) {
        Load(scene, LoadSceneMode.Single);
    }

    public static void LoadAdditive(string scene) {
        Load(scene, LoadSceneMode.Additive);
    }

    private static void Load(string scene, LoadSceneMode mode) {
        SceneManager.LoadScene(scene, mode);
    }

}