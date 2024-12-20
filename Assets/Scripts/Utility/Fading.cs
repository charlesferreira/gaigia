﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility {

    public class Fading : MonoBehaviour {

        public enum Direction {
            FadeIn = -1,
            FadeOut = 1,
        }

        public Texture2D fadeOutTexture;
        public float fadeSpeed;

        private int drawDepth = -1000;
        private float alpha = 1.0f;
        private Direction fadeDirection = Direction.FadeIn;

        public float FadingDuration { get { return 1f / fadeSpeed; } }

        public float BeginFade(Direction direction) {
            fadeDirection = direction;
            return fadeSpeed;
        }

        private void OnSceneWasLoaded(Scene scene, LoadSceneMode mode) {
            BeginFade(Direction.FadeIn);
        }

        private void OnGUI() {
            alpha += (int)fadeDirection * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
            GUI.depth = drawDepth;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
        }

        private void OnEnable() {
            SceneManager.sceneLoaded += OnSceneWasLoaded;
        }

        private void OnDisable() {
            SceneManager.sceneLoaded -= OnSceneWasLoaded;
        }
    }
}