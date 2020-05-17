using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerSelectedItems = 0;
    public static GameManager instance = null;
    public Canvas canvas;

    public Text levelText;
    public GameObject levelImage;
    public GameObject infoTextImage;
    public Text infoText;

    private int level = 1;
    private bool playersTurn = true;
    private bool canPlayerMove = true;

    private ShopList shopList;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        instance.InitGame();
    }

    void InitGame()
    {
        canPlayerMove = true;
        levelImage.SetActive(false);
        infoTextImage.SetActive(false);
    }

    void Update()
    {
        if (playersTurn)
            return;

        //StartCoroutine(MoveEnemies ());
    }

    public void GameOver()
    {
        levelText.text = "Game Over";
        levelImage.SetActive(true);
        canPlayerMove = false;
        enabled = false;
        MainManager.instance.SayHello();
        StartCoroutine(BackToMainMenu());
    }

    private IEnumerator BackToMainMenu()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void LevelComplete()
    {
        if (playerSelectedItems >= PointsManager.instance.currentLevel)
        {
            levelText.text = "Shoping complete!";
            levelImage.SetActive(true);
            enabled = false;
            PointsManager.instance.LevelUp();
            Invoke("Restart", 1);
        }
        else
        {
            StartCoroutine(ShowInfoText());
        }
    }


    private IEnumerator ShowInfoText()
    {
        infoTextImage.SetActive(true);
        infoText.text = (PointsManager.instance.currentLevel - playerSelectedItems).ToString() + "items left :<"; 
        yield return new WaitForSeconds(1);
        infoTextImage.SetActive(false);
    }

    public bool CanPlayerMove()
    {
        return canPlayerMove;
    }

    private void Restart()
    {
        SceneManager.LoadScene("Shop", LoadSceneMode.Single);
    }
}