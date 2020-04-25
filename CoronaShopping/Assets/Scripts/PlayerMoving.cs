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
        if (other.CompareTag("ShopItem"))
        {
            GameManager.instance.playerFoodPoints++;
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Corona"))
        {
            GameManager.instance.GameOver();
            print("corona");
        }
        else if (other.CompareTag("CashDesk"))
        {
            GameManager.instance.LevelComplete();
            print("corona");
        }
    }
}