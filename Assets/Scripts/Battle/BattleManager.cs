using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    [SerializeField] private List<Character> _characters;
    [SerializeField] private MovementArea _movementArea;
    [SerializeField] private SkillRange _skillRange;
    [SerializeField] private SkillTarget _skillTarget;
    [SerializeField] private SkillSetHUD _skillSetHUD;
    [SerializeField] private ActionSequence _actionSequence;

    private IBattleState CurrentState { get; set; }
    private IList<IBattleState> States { get; set; }
    private int ActiveCharacterIndex { get; set; }
    private int SelectedTargetIndex { get; set; }

    public Character Character { get { return Characters[ActiveCharacterIndex]; } }
    public Character Target { get { return Targets[SelectedTargetIndex]; } }
    public IList<Character> Characters { get { return _characters.AsReadOnly(); } }
    public IList<Character> Targets { get; set; }

    public MovementArea MovementArea { get { return _movementArea; } }
    public SkillRange SkillRange { get { return _skillRange; } }
    public SkillTarget SkillTarget { get { return _skillTarget; } }
    public SkillSetHUD SkillSetHUD { get { return _skillSetHUD; } }
    public ActionSequence ActionSequence { get { return _actionSequence; } }

    public void Reset() {
        ActiveCharacterIndex = -1;
        SetState<PrepareNextTurnBattleState>();
    }

    public void SetState<T>() where T : IBattleState {
        if (CurrentState != null)
            CurrentState.OnStateExit(this);
        CurrentState = States.OfType<T>().First();
        CurrentState.OnStateEnter(this);
    }

    private void SetUpStates() {
        States = new List<IBattleState> {
            new SetUpBattleState(),
            new PrepareNextTurnBattleState(),
            new SetSkillAndPositionBattleState(),
            new SelectTargetBattleState(),
            new CastSkillBattleState(),
        };
        SetState<SetUpBattleState>();
    }

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

    private void Awake() {
        Targets = new List<Character>();
    }

    private void Start() {
        ActionSequence.CreatePortraits(Characters);
        SetUpStates();
    }

    private void Update() {
        CurrentState.Update(this);
    }
}
