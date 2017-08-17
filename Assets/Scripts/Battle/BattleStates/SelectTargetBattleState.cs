using System.Collections.Generic;
using System.Linq;

public class SelectTargetBattleState : IBattleState {

    private IList<Character> targets;
    private int targetIndex;

    private Character Target { get { return targets[targetIndex]; } }

    public void OnStateEnter(IBattleStateMachine fsm) {
        SetTargets(fsm);
        FocusOnTarget();
        SkillTarget.Instance.SetActive(targets.Count > 0);
    }

    public void OnStateExit(IBattleStateMachine battleManager) {
        SkillTarget.Instance.SetActive(false);
    }

    public void Update(IBattleStateMachine fsm) {
        if (PlayerInput.Confirm) {
            fsm.SelectNextCharacter();
            fsm.SetState<SelectSkillAndPositionBattleState>();
        }

        if (PlayerInput.RightShoulder) {
            SelectNextTarget();
        }

        if (PlayerInput.LeftShoulder) {
            SelectPreviousTarget();
        }
    }

    public void FixedUpdate(IBattleStateMachine fsm) { }

    private void SetTargets(IBattleStateMachine fsm) {
        targetIndex = 0;
        var character = fsm.ActiveCharacter;
        targets = fsm.Characters
            .Where(x => character.Skill.Hits(x, character))
            .OrderBy(x => x.SqrDistance(character)).ToList();
    }

    private void SelectNextTarget() {
        if (targets.Count == 0) return;

        targetIndex += 1;
        targetIndex %= targets.Count;
        FocusOnTarget();
    }

    private void SelectPreviousTarget() {
        if (targets.Count == 0) return;

        targetIndex -= 1;
        while (targetIndex < 0)
            targetIndex += targets.Count;
        FocusOnTarget();
    }

    private void FocusOnTarget() {
        if (targets.Count == 0) return;

        SkillTarget.Instance.SetTarget(Target);
        BattleCamera.Instance.SetTarget(Target.transform);
    }
}