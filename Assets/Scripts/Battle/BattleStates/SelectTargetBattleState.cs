using System.Collections.Generic;

public class SelectTargetBattleState : IBattleState {

    private int targetIndex;

    public void OnStateEnter(IBattleStateMachine fsm) {
        targetIndex = 0;
        FocusOnTarget(fsm.Targets[targetIndex]);
        SkillTarget.Instance.SetActive(true);
    }

    public void OnStateExit(IBattleStateMachine battleManager) {
        SkillTarget.Instance.SetActive(false);
    }

    public void Update(IBattleStateMachine fsm) {
        if (PlayerInput.Cancel) {
            fsm.SetState<SelectSkillAndPositionBattleState>();
            return;
        }

        if (PlayerInput.RightShoulder) { SelectNextTarget(fsm.Targets); }
        if (PlayerInput.LeftShoulder)  { SelectPreviousTarget(fsm.Targets); }
        if (PlayerInput.Confirm) {
            fsm.SelectNextCharacter();
            fsm.SetState<ExecuteSkillBattleState>();
        }
    }

    private void SelectNextTarget(IList<Character> targets) {
        targetIndex += 1;
        targetIndex %= targets.Count;
        FocusOnTarget(targets[targetIndex]);
    }

    private void SelectPreviousTarget(IList<Character> targets) {
        targetIndex -= 1;
        while (targetIndex < 0)
            targetIndex += targets.Count;
        FocusOnTarget(targets[targetIndex]);
    }

    private void FocusOnTarget(Character character) {
        SkillTarget.Instance.SetTarget(character);
        BattleCamera.Instance.SetTarget(character.transform);
    }
}