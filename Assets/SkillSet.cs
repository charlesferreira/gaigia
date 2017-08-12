using System.Collections.Generic;
using UnityEngine;

public class SkillSet : MonoBehaviour {

    [SerializeField] private List<Skill> skills;

    private int currentSkillIndex;

    public IList<Skill> Skills { get { return skills.AsReadOnly(); } }

    public int CurrentSkillIndex {
        get { return currentSkillIndex; }
        set { currentSkillIndex = (currentSkillIndex + value) % Count; }
    }

    public Skill CurrentSkill { get { return skills[currentSkillIndex]; } }

    public int Count { get { return skills.Count; } }

    public void SetActive(bool active) {
        enabled = active;
    }

    private void Awake() {
        currentSkillIndex = 0;
    }

    private void Update() {
        if (PlayerInput.LeftShoulder) {
            CurrentSkillIndex--;
            SkillSetHUD.Instance.SelectPreviousSkill();
        }

        if (PlayerInput.RightShoulder) {
            CurrentSkillIndex++;
            SkillSetHUD.Instance.SelectNextSkill();
        }
    }
}
