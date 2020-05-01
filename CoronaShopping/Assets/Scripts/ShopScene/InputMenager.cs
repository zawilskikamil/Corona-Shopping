using System;
using UnityEngine;

public class InputManager
{
    public static bool IsUp()
    {
        return Input.GetKey(KeyCode.W);
    }

    internal static bool IsDown()
    {
        return Input.GetKey(KeyCode.S);
    }

    public static bool IsRight()
    {
        return Input.GetKey(KeyCode.D);
    }

    internal static bool IsLeft()
    {
        return Input.GetKey(KeyCode.A);
    }


}
