using System.Collections.Generic;

public interface IBattleStateMachine {

    Character ActiveCharacter { get; }

    IList<Character> Characters { get; }

    void SelectNextCharacter();

    void SetState<T>() where T : IBattleState;
}
