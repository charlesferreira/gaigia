using System.Collections.Generic;
using UnityEngine;

public class MainMenu : SimpleStateMachine<MainMenu> {

    public Character Character { get; private set; }

    protected override IList<ISimpleState<MainMenu>> CreateStates() {
        return new List<ISimpleState<MainMenu>> {
            new Level1MainMenuState()
        };
    }

    new void Awake() {
        base.Awake();
        Character = CombatInfo.Instance.PlayerCharacters[0];
        print(Character.Team);
    }
}
