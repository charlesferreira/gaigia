using UnityEngine;

abstract public class BasicSkill : Skill {

    [SerializeField] private string _name;
    [SerializeField] private Sprite icon;
    [Range(0, 20)]
    [SerializeField] private float range;
    [Range(0,9)]
    [SerializeField] private int cost;

    public override string Name { get { return _name; } }
    public override Sprite Icon { get { return icon; } }
    public override float Range { get { return range; } }
    public override int Cost { get { return cost; } }
}
