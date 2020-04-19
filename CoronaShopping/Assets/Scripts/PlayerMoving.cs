using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoving : MovingObject
{
    private Animator animator;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }

    void Update()
    {
        if (InputManager.IsUp())
        {
            base.Move(0, 1);
            animator.SetTrigger("PlayerGoUp");
        }
        else if (InputManager.IsDown())
        {
            base.Move(0, -1);
            animator.SetTrigger("PlayerGoDown");
        }
        else if (InputManager.IsLeft())
        {
            base.Move(-1, 0);
            animator.SetTrigger("PlayerGoLeft");
        }
        else if (InputManager.IsRight())
        {
            base.Move(1, 0);
            animator.SetTrigger("PlayerGoRight");

        }
    }
}