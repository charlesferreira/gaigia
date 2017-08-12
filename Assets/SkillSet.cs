using System.Collections.Generic;
using UnityEngine;

public class SkillSet : MonoBehaviour {

    [SerializeField] private List<Skill> skills;

    private int currentSkillIndex;

    public IList<Skill> Skills { get { return skills.AsReadOnly(); } }
    public int CurrentSkillIndex { get { return currentSkillIndex; } }
    public Skill CurrentSkill { get { return skills[currentSkillIndex]; } }

    private void Awake() {
        currentSkillIndex = 0;
    }

    private void Update() {
        
    }
}
