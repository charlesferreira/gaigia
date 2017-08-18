using System.Collections.Generic;

public interface IBattleStateMachine {

    Character ActiveCharacter { get; }

    IList<Character> Targets { get; }

    void SetState<T>() where T : IBattleState;

    void ActivateCurrentCharacter();

    void SelectNextCharacter();

    void UpdateTargets();
}
