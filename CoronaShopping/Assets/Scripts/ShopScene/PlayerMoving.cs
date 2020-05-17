using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoving : MovingObject
{

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        if (!GameManager.instance.CanPlayerMove())
        {
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
            GameManager.instance.playerSelectedItems++;
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Corona"))
        {
            GameManager.instance.GameOver();
        }
        else if (other.CompareTag("CashDesk"))
        {
            GameManager.instance.LevelComplete();
        }
    }
}