using UnityEngine;

public class PlayerMoving : MovingObject
{

    public AudioClip CollectShopItemAudio1;
    public AudioClip CollectShopItemAudio2;
    public AudioClip GameOverAudio1;
    public AudioClip GameOverAudio2;
    public AudioClip CompliteCashDeskAudio1;
    public AudioClip CompliteCashDeskAudio2;
    public AudioClip NotCompliteCashDeskAudio2;
    public AudioClip NotCompliteCashDeskAudio1;

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
            SoundManager.instance.RandomizeSfx(CollectShopItemAudio1, CollectShopItemAudio2);
        }
        else if (other.CompareTag("Corona"))
        {
            SoundManager.instance.RandomizeSfx(GameOverAudio1, GameOverAudio2);
            GameManager.instance.GameOver();
        }
        else if (other.CompareTag("CashDesk"))
        {
            bool completed = GameManager.instance.LevelComplete();
            if (completed)
            {
                SoundManager.instance.RandomizeSfx(CompliteCashDeskAudio2, CompliteCashDeskAudio1);
            }
            else
            {
                SoundManager.instance.RandomizeSfx(NotCompliteCashDeskAudio2, NotCompliteCashDeskAudio1);
            }
        }
    }
}