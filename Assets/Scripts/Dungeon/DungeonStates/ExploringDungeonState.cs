using UnityEngine;

public class ExploringDungeonState : ISimpleState<DungeonManager> {

    public void OnStateEnter(DungeonManager dm) { }

    public void OnStateExit(DungeonManager dm) { }

    public void Update(DungeonManager dm) {
        var input = new Vector2(PlayerInput.LeftStickHorizontal, PlayerInput.LeftStickVertical);
        dm.Character.Movement.Walk(input);
    }
}

//using UnityEngine;

//public class ExploringPositionBattleState : IDungeonState {

//    public void OnStateEnter(DungeonManager dm) {
//        //bm.ActivateCurrentCharacter();
//        //CameraMan.Instance.SetTarget(bm.Character.transform);
//    }

//    public void OnStateExit(DungeonManager dm) {
//        //bm.Character.Movement.Stop();
//    }

//    public void Update(DungeonManager dm) {
//        //bm.UpdateTargets();
//        //SetCameraPan();
//        //SetPosition(bm);
//        //SelectSkill(bm);
//        //UpdateSkillRange(bm);
//    }

//    //private void SetPosition(BattleManager bm) {
//    //    var input = new Vector2(PlayerInput.LeftStickHorizontal, PlayerInput.LeftStickVertical);
//    //    bm.Character.Movement.Walk(input);
//    //}

//    //private void SetCameraPan() {
//    //    var panX = PlayerInput.RightStickHorizontal;
//    //    var panZ = PlayerInput.RightStickVertical;
//    //    CameraMan.Instance.Pan(panX, panZ);
//    //}

//    //private void SelectSkill(BattleManager bm) {
//    //    if (PlayerInput.RightShoulder) {
//    //        bm.Character.SelectNextSkill(bm.SkillRange);
//    //    }
//    //    if (PlayerInput.LeftShoulder) {
//    //        bm.Character.SelectPreviousSkill(bm.SkillRange);
//    //    }
//    //    if (PlayerInput.Confirm && bm.SkillIsReady()) {
//    //        bm.SetState<SelectTargetBattleState>();
//    //    }
//    //}

//    //private void UpdateSkillRange(BattleManager bm) {
//    //    bm.SkillRange.UpdateColor(bm.Character.HasEnoughAP(), bm.Targets.Count > 0);
//    //}
//}