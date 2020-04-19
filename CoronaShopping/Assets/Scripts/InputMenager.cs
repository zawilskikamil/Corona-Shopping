using System;
using UnityEngine;

public class InputManager
{
    public static bool IsUp()
    {
        return Input.GetKeyDown(KeyCode.W);
    }

    internal static bool IsDown()
    {
        return Input.GetKeyDown(KeyCode.S);
    }

    public static bool IsRight()
    {
        return Input.GetKeyDown(KeyCode.D);
    }

    internal static bool IsLeft()
    {
        return Input.GetKeyDown(KeyCode.A);
    }


}
