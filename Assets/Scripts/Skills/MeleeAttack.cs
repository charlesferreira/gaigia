using System.Collections;
using UnityEngine;

public class MeleeAttack : Skill {
    
    [Range(1, 9)]
    [SerializeField] private int cost;

    public override IEnumerator OnCast(Character source, Character target) {
        var camera = CameraMan.Instance;

        camera.SetTarget(source.transform);
        source.Animation.SetState(CharacterAnimationState.Casting);
        yield return new WaitForSeconds(1);

        camera.SetTarget(target.transform);
        source.Animation.SetState(CharacterAnimationState.Idle);
        target.Animation.SetState(CharacterAnimationState.Casting);

        yield return new WaitForSeconds(1.0f);
        target.Animation.SetState(CharacterAnimationState.Idle);
        target.Health.TakeDamage(CalculateDamage(source));
    }

    public override string GetName(Character character) {
        return character.Weapon.Name;
    }

    public override Sprite GetIcon(Character character) {
        return character.Weapon.Icon;
    }

    public override float GetRange(Character character) {
        return character.Weapon.Range;
    }

    public override int GetCost(Character character) {
        return cost;
    }

    private int CalculateDamage(Character character) {
        return 17;
    }
}
