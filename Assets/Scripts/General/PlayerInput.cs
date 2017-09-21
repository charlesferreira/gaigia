using UnityEngine;

public static class PlayerInput {

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

    public static bool AnalogUp { get { return LeftStickVertical < 0; } }
    public static bool AnalogDown { get { return LeftStickVertical > 0; } }
    public static bool AnalogLeft { get { return LeftStickHorizontal < 0; } }
    public static bool AnalogRight { get { return LeftStickHorizontal > 0; } }

    public static bool DPadUp { get { return DPadVertical < 0; } }
    public static bool DPadDown { get { return DPadVertical > 0; } }
    public static bool DPadLeft { get { return DPadHorizontal < 0; } }
    public static bool DPadRight { get { return DPadHorizontal > 0; } }

    public static bool Up { get { return AnalogUp || DPadUp; } }
    public static bool Down { get { return AnalogDown || DPadDown; } }
    public static bool Left { get { return AnalogLeft || DPadLeft; } }
    public static bool Right { get { return AnalogRight || DPadRight; } }
}