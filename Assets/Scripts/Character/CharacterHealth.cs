using UnityEngine;

public class CharacterHealth : MonoBehaviour {

    [SerializeField] private HitTextController hitTextPrefab;

    public int HP { get; private set; }

    public void TakeDamage(int amount) {
        HP = Mathf.Max(0, HP - amount);

        var hitText = Instantiate(hitTextPrefab, transform);
        hitText.SetText(amount.ToString());
    }

    private void Start() {
        HP = GetComponent<Character>().Stats.MaxHP;
    }
}