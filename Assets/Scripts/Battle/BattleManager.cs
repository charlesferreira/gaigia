using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : SimpleStateMachine<BattleManager> {

    [SerializeField] private MovementArea _movementArea;
    [SerializeField] private SkillRange _skillRange;
    [SerializeField] private SkillTarget _skillTarget;
    [SerializeField] private SkillSetHUD _skillSetHUD;
    [SerializeField] private ActionSequence _actionSequence;
    [SerializeField] private List<PlayerStatusHUD> playerStatusHUDList;
    [SerializeField] private List<Transform> spawnPoints;

    private int ActiveCharacterIndex { get; set; }
    private int SelectedTargetIndex { get; set; }
    
    public Character Character { get { return Characters[ActiveCharacterIndex]; } }
    public Character Target { get { return Targets[SelectedTargetIndex]; } }
    public IList<Character> Characters { get; private set; }
    //public List<Character> Characters;
    public IList<Character> Targets { get; set; }

    public MovementArea MovementArea { get { return _movementArea; } }
    public SkillRange SkillRange { get { return _skillRange; } }
    public SkillTarget SkillTarget { get { return _skillTarget; } }
    public SkillSetHUD SkillSetHUD { get { return _skillSetHUD; } }
    public ActionSequence ActionSequence { get { return _actionSequence; } }

    public void SelectNextCharacter() {
        ActiveCharacterIndex += 1;
        ActiveCharacterIndex %= Characters.Count;
        ActivateCurrentCharacter();
    }

    public void ActivateCurrentCharacter() {
        for (var i = 0; i < Characters.Count; i++)
            Characters[i].SetActive(i == ActiveCharacterIndex);
    }

    public void SelectNextTarget() {
        SelectedTargetIndex += 1;
        SelectedTargetIndex %= Targets.Count;
    }

    public void SelectPreviousTarget() {
        SelectedTargetIndex += Targets.Count - 1;
        SelectedTargetIndex %= Targets.Count;
    }

    public void ResetTarget() {
        SelectedTargetIndex = 0;
    }

    public void UpdateTargets() {
        Targets = Characters
            .Where(x => Character.Skill.Hits(Character, x))
            .OrderBy(x => x.SqrDistance(Character)).ToList();
    }

    public bool SkillIsReady() {
        return Character.AP.Left >= Character.Skill.GetCost(Character) && Targets.Count > 0;
    }

    protected override IList<ISimpleState<BattleManager>> CreateStates() {
        return new List<ISimpleState<BattleManager>> {
            new SetUpBattleState(),
            new PrepareNextTurnBattleState(),
            new SetSkillAndPositionBattleState(),
            new SelectTargetBattleState(),
            new CastSkillBattleState(),
        };
    }

    protected new void Awake() {
        base.Awake();
        Targets = new List<Character>();
    }

    protected new void Start() {
        base.Start();
        ActiveCharacterIndex = -1;
        CreateCharacters();
        SetState<PrepareNextTurnBattleState>();
        ActionSequence.CreatePortraits(this);
    }

    private void CreateCharacters() {
        Characters = new List<Character>();
        var characters = PlayerParty.Instance.Characters;
        for (var i = 0; i < characters.Count; i++) {
            var character = characters[i];
            Characters.Add(character);
            character.transform.position = spawnPoints[i].position;
            playerStatusHUDList[i].SetUp(character);
        }
    }
}
