using System.Collections;
using UnityEngine;

public class FireBall : BasicSkill {

    [Range(0, 100)]
    [SerializeField] private int baseDamage;

    public override IEnumerator OnCast(Character source, Character target) {
        var camera = CameraMan.Instance;

        camera.SetTarget(source.transform);
        source.Animation.SetState(CharacterAnimationState.Casting);
        yield return new WaitForSeconds(2f);

        camera.SetTarget(target.transform);
        source.Animation.SetState(CharacterAnimationState.Idle);
        target.Animation.SetState(CharacterAnimationState.Casting);

        yield return new WaitForSeconds(0.75f);
        target.Animation.SetState(CharacterAnimationState.Idle);
        target.Health.TakeDamage(CalculateDamage(source, target));
    }

    private int CalculateDamage(Character source, Character target) {
        int damage = 0;
        damage += source.Stats.Mind + baseDamage;
        damage -= target.Stats.Mind + target.Armor.Defense;
        return Mathf.Max(0, damage);
    }
}
