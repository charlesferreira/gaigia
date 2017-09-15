using System.Collections;
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

    [Header("Temp")]
    public GameObject gameOverVictory;
    public GameObject gameOverDefeat;


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

    public bool HasAlive(Team team) {
        foreach (var character in Characters) {
            if (character.Team == team && character.IsAlive)
                return true;
        }
        return false;
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
    
    public void RemoveDeads() {
        for (int i = 0; i < Characters.Count; i++) {
            if (!Characters[i].IsAlive) {
                ActionSequence.MarkDead(i);
            }
        }
    }

    protected override IList<ISimpleState<BattleManager>> CreateStates() {
        return new List<ISimpleState<BattleManager>> {
            new SetUpBattleState(),
            new PrepareNextTurnBattleState(),
            new SetSkillAndPositionBattleState(),
            new SelectTargetBattleState(),
            new CastSkillBattleState(),
            new EndOfTurnBattleState(),
            new GameOverBattleState(),
        };
    }

    private void SetUpPlayerCharacters() {
        Characters = new List<Character>();
        CombatInfo.Instance.ResetPlayerPositions();
        var characters = CombatInfo.Instance.PlayerCharacters;
        for (var i = 0; i < characters.Length; i++) {
            var character = characters[i];
            Characters.Add(character);
            playerStatusHUDList[i].SetUp(character);
        }
    }

    private void CreateEnemies() {
        var enemies = CombatInfo.Instance.EnemyParty.CreateCharacters();
        for (var i = 0; i < enemies.Length; i++) {
            Characters.Add(enemies[i]);
        }
    }
    
    private void OrderByDexterity() {
        var rng = new System.Random();
        var list = Characters;
        int n = list.Count;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            Character value = Characters[k];
            Characters[k] = Characters[n];
            list[n] = value;
        }
    }

    public void ShowGameOverScreen() {
        if (HasAlive(Team.Player))
            gameOverVictory.SetActive(true);
        else
            gameOverDefeat.SetActive(true);

        StartCoroutine(ResetToTitleScreen());
    }

    private IEnumerator ResetToTitleScreen() {
        yield return new WaitForSecondsRealtime(4);

        Application.Quit();
    }

    protected new void Awake() {
        base.Awake();
        Targets = new List<Character>();
    }

    protected new void Start() {
        base.Start();
        ActiveCharacterIndex = -1;
        SetUpPlayerCharacters();

        // temp
        CreateEnemies();
        OrderByDexterity();

        SetState<PrepareNextTurnBattleState>();
        ActionSequence.CreatePortraits(this);
    }
}
