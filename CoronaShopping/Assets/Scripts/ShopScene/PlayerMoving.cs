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
        if (!GameManager.instance.CanPlayerMove())
        {
            print("cant move");
            return;
        }
        
        if (InputManager.IsUp())
        {
            Move(Direction.UP);
        }
        if (InputManager.IsDown())
        {
            Move(Direction.DOWN);
        }
        if (InputManager.IsLeft())
        {
            Move(Direction.LEFT);
        }
        if (InputManager.IsRight())
        {
            Move(Direction.RIGHT);
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
        }
        else if (other.CompareTag("CashDesk"))
        {
            GameManager.instance.LevelComplete();
            print("corona");
        }
    }
}