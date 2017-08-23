using UnityEngine;

abstract public class BasicSkill : Skill {

    [SerializeField] private string _name;
    [SerializeField] private Sprite icon;
    [Range(0, 20)]
    [SerializeField] private float range;
    [Range(0,9)]
    [SerializeField] private int cost;

    public override Sprite GetIcon(Character character) {
        return icon;
    }

    public override string GetName(Character character) {
        return _name;
    }

    public override float GetRange(Character character) {
        return range;
    }

    public override int GetCost(Character character) {
        return cost;
    }
}
