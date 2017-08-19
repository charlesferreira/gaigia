using System.Collections.Generic;

public interface IBattleStateMachine {

    Character ActiveCharacter { get; }

    IList<Character> Characters { get; }

    IList<Character> Targets { get; set; }

    Character SelectedTarget { get; }

    void Reset();

    void SetState<T>() where T : IBattleState;

    void ActivateCurrentCharacter();

    void SelectNextCharacter();

    void ResetTarget();

    void SelectNextTarget();

    void SelectPreviousTarget();

    void UpdateTargets();
}
