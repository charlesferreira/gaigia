using UnityEngine;
using UnityEngine.UI;


public class PlayerStatusHUD : MonoBehaviour {

    [SerializeField] private Character character;
    [SerializeField] private Image avatar;
    [SerializeField] private Text apMeterNumber;
    [SerializeField] private RectTransform healthMeter;
    [SerializeField] private Text healthMeterNumber;
    [SerializeField] private RectTransform energyMeter;
    [SerializeField] private Text energyMeterNumber;

    private float BaseWidth { get; set; }

    private void Start() {
        BaseWidth = healthMeter.sizeDelta.x;

        avatar.color = character.GetComponentInChildren<SpriteRenderer>().color;
    }

    private void Update() {
        apMeterNumber.text = character.AP.Left.ToString();

        var hpRatio = (float)character.Health.HP / character.Stats.MaxHP;
        healthMeter.sizeDelta = new Vector2(BaseWidth * hpRatio, healthMeter.sizeDelta.y);

        healthMeterNumber.text = character.Health.HP.ToString();
        healthMeterNumber.enabled = character.Health.HP > 0;


        var meRatio = (float)character.Health.ME / character.Stats.MaxME;
        energyMeter.sizeDelta = new Vector2(BaseWidth * meRatio, energyMeter.sizeDelta.y);

        energyMeterNumber.text = character.Health.ME.ToString();
        energyMeterNumber.enabled = character.Health.ME > 0;
    }

}
