using UnityEngine;

public class CharacterHealth : MonoBehaviour {

    [SerializeField] private HitTextController hitTextPrefab;

    private SpriteRenderer sr;

    public int HP { get; private set; }
    public int ME { get; set; }

    public void TakeDamage(int amount) {
        HP = Mathf.Max(0, HP - amount);

        CreateHitText(amount, HitTextController.Type.Damage);
    }

    public void Heal(StatsSheet stats, int amount) {
        HP = Mathf.Min(stats.MaxHP, HP + amount);

        CreateHitText(amount, HitTextController.Type.Healing);
    }

    public void SetUp() {
        var stats = GetComponent<Character>().Stats;
        HP = stats.MaxHP;
        ME = stats.MaxME;
    }

    private void CreateHitText(int amount, HitTextController.Type type) {
        var hitText = Instantiate(hitTextPrefab, sr.transform);
        hitText.SetText(amount.ToString(), type);
        hitText.SetY(sr.GetMaxY());
        hitText.transform.SetParent(transform);
        hitText.FixXScale();
    }

    private void Awake() {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start() {
        SetUp();
    }
}