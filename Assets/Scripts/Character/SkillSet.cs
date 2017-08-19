using System.Collections.Generic;
using UnityEngine;

public class SkillSet : MonoBehaviour {

    [SerializeField] private List<Skill> skills;

    private int _currentSkillIndex;

    public IList<Skill> Skills { get { return skills.AsReadOnly(); } }

    public int CurrentSkillIndex {
        get { return _currentSkillIndex; }
        set {
            _currentSkillIndex = (value + Count) % Count;
            SkillRange.Instance.SetSkill(CurrentSkill);
        }
    }

    public Skill CurrentSkill { get { return skills[CurrentSkillIndex]; } }

    public int Count { get { return skills.Count; } }

    public Skill this[int key] { get { return Skills[key]; } }

    public void SelectNextSkill() {
        CurrentSkillIndex += 1;
    }

    public void SelectPreviousSkill() {
        CurrentSkillIndex -= 1;
    }

    public void SetActive(bool active) {
        enabled = active;
    }

    private void Awake() {
        CurrentSkillIndex = 0;
    }
}
