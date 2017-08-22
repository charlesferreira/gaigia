using UnityEngine;

public class SkillRange : Singleton<SkillRange> {

    [SerializeField] private SpriteRenderer circle;

    private Skill Skill { get; set; }

    public bool SkillIsReady {
        get {
            return BattleManager.Instance.ActiveCharacter.AP.Left >= Skill.Cost
                && BattleManager.Instance.Targets.Count > 0;
        }
    }

    public void SetUp(Character character) {
        SetActive(character.Team == Team.Player);
        SetParent(character.transform);
        SetSkill(character.Skill);
    }

    public void SetSkill(Skill skill) {
        Skill = skill;
        transform.localScale = Vector3.one * skill.Range * 2;
    }

    private void SetActive(bool active) {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(active);
        }
    }

    private void SetParent(Transform parent) {
        transform.SetParent(parent);
        SetPosition(parent.position);
    }

    private void SetPosition(Vector3 position) {
        position.y = transform.position.y;
        transform.position = position;
    }

    private void Update() {
        circle.color = BattleManager.Instance.ActiveCharacter.AP.Left < Skill.Cost
            ? Color.red
            : BattleManager.Instance.Targets.Count > 0
                ? Color.white
                : Color.yellow;

    }
}
