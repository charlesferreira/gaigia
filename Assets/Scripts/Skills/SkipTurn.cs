using System.Collections;

public class SkipTurn: BasicSkill {

    public override IEnumerator OnCast(Character source, Character target) {
        yield return null;
    }
}
