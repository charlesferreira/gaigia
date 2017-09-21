using System.Collections.Generic;

public class MainMenu : SimpleStateMachine<MainMenu> {

    protected override IList<ISimpleState<MainMenu>> CreateStates() {
        return new List<ISimpleState<MainMenu>> {
            new Level1MainMenuState()
        };
    }
}
