using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility {

    public class LoadSceneOnClick : MonoBehaviour {

        public SceneField scene;

        public void LoadScene() {
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut() {
            var fading = FindObjectOfType<Fading>();
            fading.BeginFade(Fading.Direction.FadeOut);
            yield return new WaitForSeconds(fading.FadingDuration);

            SceneManager.LoadScene(scene);
        }
    }
}