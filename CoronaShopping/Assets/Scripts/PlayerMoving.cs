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
        float x = 0;
        float y = 0;
        string trigger = "";
        if (InputManager.IsUp())
        {
            y = 1;
            trigger = "PlayerGoUp";
        }
        if (InputManager.IsDown())
        {
            y = -1;
            trigger = "PlayerGoDown";
        }
        if (InputManager.IsLeft())
        {
            x = -1;
            trigger = "PlayerGoLeft";
        }
        if (InputManager.IsRight())
        {
            x = 1;
            trigger = "PlayerGoRight";
        }
        if (x == 0 && y == 0)
        {
            return;
        }
        bool moving = base.Move(x, y);
        if (moving)
        {
            animator.SetTrigger(trigger);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other);
        print(other.tag);
        print(other.gameObject);
        if (other.tag == "ShopItem")
        {
            //Disable the food object the player collided with.
            other.gameObject.SetActive(false);
        }
    }
}