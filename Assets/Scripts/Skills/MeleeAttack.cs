using System.Collections;
using UnityEngine;

public class MeleeAttack : Skill {
    
    [Range(1, 9)]
    [SerializeField] private int cost;

    public override IEnumerator OnCast(Character source, Character target) {
        var camera = CameraMan.Instance;
        
        camera.SetTarget(source.transform);
        source.Animation.SetState(CharacterAnimationState.Idle);
        yield return new WaitForSeconds(0.3f);

        source.Animation.SetState(CharacterAnimationState.Attacking);
        target.Animation.SetState(CharacterAnimationState.Idle);

        yield return new WaitForSeconds(0.5f);
        camera.SetTarget(target.transform);
        yield return new WaitForSeconds(0.5f);
        target.Animation.SetState(CharacterAnimationState.Idle);
        target.Health.TakeDamage(CalculateDamage(source, target));
        yield return new WaitForSeconds(0.2f);
    }

    public override string GetName(Character character) {
        return character.Weapon.name;
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

    private int CalculateDamage(Character source, Character target) {
        int damage = 0;
        damage += source.Stats.Strength + source.Weapon.Attack;
        damage -= target.Stats.Strength + target.Armor.Defense;
        return Mathf.Max(0,  damage);
    }
}
