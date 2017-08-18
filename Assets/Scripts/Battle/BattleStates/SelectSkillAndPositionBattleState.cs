using System.Linq;
using UnityEngine;

public class SelectSkillAndPositionBattleState : IBattleState {
    
    CharacterMovement characterMovement;

    public void OnStateEnter(IBattleStateMachine bsm) {
        bsm.ActivateCurrentCharacter();
        characterMovement = bsm.ActiveCharacter.GetComponent<CharacterMovement>();
        BattleCamera.Instance.SetTarget(bsm.ActiveCharacter.transform);
    }

    public void OnStateExit(IBattleStateMachine bsm) {
        characterMovement.Stop();
    }

    public void Update(IBattleStateMachine bsm) {
        UpdateTargets(bsm);
        SetPosition();
        SetCameraPan();
        SelectSkill(bsm);
    }

    private void UpdateTargets(IBattleStateMachine bsm) {
        bsm.Targets = bsm.Characters
            .Where(x => bsm.ActiveCharacter.Skill.Hits(x))
            .OrderBy(x => x.SqrDistance(bsm.ActiveCharacter)).ToList();
    }

    private void SetPosition() {
        var input = new Vector2(PlayerInput.LeftStickHorizontal, PlayerInput.LeftStickVertical);
        characterMovement.Walk(input);
    }

    private void SetCameraPan() {
        var panX = PlayerInput.RightStickHorizontal;
        var panZ = PlayerInput.RightStickVertical;
        BattleCamera.Instance.Pan(panX, panZ);
    }

    private void SelectSkill(IBattleStateMachine bsm) {
        if (PlayerInput.RightShoulder) {
            bsm.ActiveCharacter.SelectNextSkill();
        }
        if (PlayerInput.LeftShoulder) {
            bsm.ActiveCharacter.SelectPreviousSkill();
        }
        if (PlayerInput.Confirm && bsm.Targets.Count > 0) {
            bsm.SetState<SelectTargetBattleState>();
        }
    }
}