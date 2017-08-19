using System.Collections;
using UnityEngine;

public class MeleeAttack : Skill {
    
    [Range(0, 9)]
    [SerializeField] private int cost;

    public override string Name { get { return BattleManager.Instance.ActiveCharacter.Weapon.Name; } }
    public override Sprite Icon { get { return BattleManager.Instance.ActiveCharacter.Weapon.Icon; } }
    public override float Range { get { return BattleManager.Instance.ActiveCharacter.Weapon.Range; } }
    public override int Cost { get { return cost; } }

    public override IEnumerator OnCast(Character source, Character target) {
        yield return new WaitForSeconds(2);
        print("Finished running OnCast");
    }
}
