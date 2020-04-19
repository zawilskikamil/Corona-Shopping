using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoving : MovingObject
{
    //public InputManager inputManager = null;

    // Use this for initialization
    

    void Update()
    {
        if (InputManager.IsUp())
        {
            base.Move(0, 1);
        }
        else if (InputManager.IsDown())
        {
            base.Move(0, -1);
        }
        else if (InputManager.IsLeft())
        {
            base.Move(-1, 0);
        }
        else if (InputManager.IsRight())
        {
            base.Move(1, 0);
        }
    }
}