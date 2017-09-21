using UnityEngine;
using UnityEngine.UI;

public class TitleMenuItem : MonoBehaviour {

    public Image buttonA;
    public Image buttonB;

    internal void TurnOff() {
        gameObject.SetActive(false);
    }

    internal void TurnOn() {
        gameObject.SetActive(true);
    }

    internal void UpdateColor(Color color) {
        buttonB.color = color;
    }
}
