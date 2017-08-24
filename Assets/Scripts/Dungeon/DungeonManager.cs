using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : SimpleStateMachine<DungeonManager> {

    [SerializeField] private Character _character;

    public Character Character { get { return _character; } }

    protected override IList<ISimpleState<DungeonManager>> CreateStates() {
        return new List<ISimpleState<DungeonManager>> {
            new ExploringDungeonState()
        };
    }
}