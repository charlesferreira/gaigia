using System.Collections;
using UnityEngine;

public class MeleeAttack : SkillController {

    public override IEnumerator OnCast(Character source, Character target) {
        yield return new WaitForSeconds(2);
        print("Finished running OnCast");
    }
}
