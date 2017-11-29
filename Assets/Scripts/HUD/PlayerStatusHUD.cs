using UnityEngine;
using UnityEngine.UI;


public class PlayerStatusHUD : MonoBehaviour {
    
    [SerializeField] private Image avatar;
    [SerializeField] private Text apMeterNumber;
    [SerializeField] private RectTransform healthMeter;
    [SerializeField] private Text healthMeterNumber;
    [SerializeField] private RectTransform energyMeter;
    [SerializeField] private Text energyMeterNumber;

    private Character Character { get; set; }
    private float BaseWidth { get; set; }

    public void SetUp(Character character) {
        Character = character;
        avatar.sprite = character.Avatar;
        avatar.color = Character.GetComponentInChildren<SpriteRenderer>().color;
    }

    private void Start() {
        BaseWidth = healthMeter.sizeDelta.x;
    }

    private void Update() {
        //print(Character);
        apMeterNumber.text = Character.AP.Left.ToString();

        var hpRatio = (float)Character.Health.HP / Character.Stats.MaxHP;
        healthMeter.sizeDelta = new Vector2(BaseWidth * hpRatio, healthMeter.sizeDelta.y);

        healthMeterNumber.text = Character.Health.HP.ToString();
        healthMeterNumber.enabled = Character.Health.HP > 0;


        var meRatio = (float)Character.Health.ME / Character.Stats.MaxME;
        energyMeter.sizeDelta = new Vector2(BaseWidth * meRatio, energyMeter.sizeDelta.y);

        energyMeterNumber.text = Character.Health.ME.ToString();
        energyMeterNumber.enabled = Character.Health.ME > 0;
    }

}
