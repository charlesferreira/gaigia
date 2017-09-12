using System.Collections.Generic;
using UnityEngine;

public class SkillSet : MonoBehaviour {
    
    private int _currentSkillIndex;

    public List<Skill> Skills { get; private set; }

    public int CurrentSkillIndex {
        get { return _currentSkillIndex; }
        set { _currentSkillIndex = (value + Count) % Count; }
    }

    public Skill CurrentSkill { get { return Skills[CurrentSkillIndex]; } }

    public int Count { get { return Skills.Count; } }

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

    public void SetUp(List<Skill> skills) {
        Skills = skills;
    }
}
