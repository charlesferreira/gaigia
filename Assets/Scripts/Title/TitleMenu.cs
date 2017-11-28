using System.Collections;
using UnityEngine;

public class TitleMenu : MonoBehaviour {

    public TitleMenuItem[] items;
    public float timeBetweenChanges = 0.25f;

    [Header("Item blink")]
    public float blinkSpeed = 8f;
    public Color blinkColorA = Color.red;
    public Color blinkColorB = Color.blue;

    private int currentItem;
    private bool changeIsAllowed = true;

    private bool ShouldChangeSelection() {
        return changeIsAllowed && PlayerInput.LeftStickVertical != 0;
    }

    private IEnumerator ChangeSelection() {
        changeIsAllowed = false;

        items[currentItem].TurnOff();
        var increment = (int)Mathf.Sign(PlayerInput.LeftStickVertical);
        currentItem = (currentItem + increment + items.Length) % items.Length;
        items[currentItem].TurnOn();

        yield return new WaitForSecondsRealtime(timeBetweenChanges);
        changeIsAllowed = true;
    }

    private void ExecuteSelected() {
        print("Selected: " + currentItem);
        switch (currentItem) {
            case 0:
                //Scenes.LoadSingle(Scenes.Battle);
                GetComponent<Utility.LoadSceneOnClick>().LoadScene();
                break;

            case 1:
                GetComponent<Utility.QuitOnClick>().Quit();
                break;
        }
    }

    private void UpdateItemColor() {
        var t = (1f + Mathf.Cos(Time.time * blinkSpeed)) / 2f;
        var color = Color.Lerp(blinkColorA, blinkColorB, t);
        items[currentItem].UpdateColor(color);
    }

    private void Update() {
        if (PlayerInput.LeftStickVertical == 0) {
            changeIsAllowed = true;
            StopAllCoroutines();
        }

        if (ShouldChangeSelection())
            StartCoroutine(ChangeSelection());

        if (PlayerInput.Confirm)
            ExecuteSelected();

        UpdateItemColor();
    }

    private void Awake() {
        for (var i = 0; i < items.Length; i++) {
            items[i].TurnOff();
        }
        items[currentItem].TurnOn();
    }
}
