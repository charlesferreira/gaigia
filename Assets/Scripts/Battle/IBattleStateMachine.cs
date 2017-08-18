using System.Collections.Generic;

public interface IBattleStateMachine {
    
    Character ActiveCharacter { get; }

    IList<Character> Characters { get; }

    IList<Character> Targets { get; set; }

    void SetState<T>() where T : IBattleState;

    void ActivateCurrentCharacter();

    void SelectNextCharacter();
}
