using System.Collections;
using UnityEngine;

public class Cure : BasicSkill {

    [Range(0, 100)]
    [SerializeField] private int baseHealing;

    public override IEnumerator OnCast(Character source, Character target) {
        var camera = CameraMan.Instance;

        camera.SetTarget(source.transform);
        source.Animation.SetState(CharacterAnimationState.Casting);
        yield return new WaitForSeconds(2f);

        camera.SetTarget(target.transform);
        source.Animation.SetState(CharacterAnimationState.Idle);

        target.Health.Heal(target.Stats, CalculateHealing(source));
    }

    private int CalculateHealing(Character source) {
        return baseHealing + source.Stats.Mind;
    }
}
