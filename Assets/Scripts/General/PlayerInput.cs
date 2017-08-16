using UnityEngine;

public class PlayerInput {

    public static float LeftStickHorizontal { get { return Input.GetAxis("Horizontal"); } }

    public static float LeftStickVertical { get { return Input.GetAxis("Vertical"); } }

    public static float RightStickHorizontal { get { return Input.GetAxis("Right Horizontal"); } }

    public static float RightStickVertical { get { return Input.GetAxis("Right Vertical"); } }

    public static float DPadHorizontal { get { return Input.GetAxis("DPad Horizontal"); } }

    public static float DPadVertical { get { return Input.GetAxis("DPad Vertical"); } }

    public static bool LeftShoulder { get { return Input.GetButtonDown("Left Shoulder"); } }

    public static bool RightShoulder { get { return Input.GetButtonDown("Right Shoulder"); } }

    public static bool Confirm { get { return Input.GetButtonDown("Submit"); } }

    public static bool Cancel { get { return Input.GetButtonDown("Cancel"); } }
}