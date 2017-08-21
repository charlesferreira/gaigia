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
        var camera = BattleCamera.Instance;

        camera.SetTarget(source.transform);
        source.Animation.SetState(CharacterAnimationState.Casting);
        yield return new WaitForSeconds(1);

        camera.SetTarget(target.transform);
        source.Animation.SetState(CharacterAnimationState.Idle);
        target.Animation.SetState(CharacterAnimationState.Casting);

        yield return new WaitForSeconds(0.8f);
        target.Health.TakeDamage(CalculateDamage(source));
        yield return new WaitForSeconds(0.2f);

        target.Animation.SetState(CharacterAnimationState.Idle);
        yield return new WaitForSeconds(0.2f);
    }

    private int CalculateDamage(Character character) {
        return 17;
    }
}
