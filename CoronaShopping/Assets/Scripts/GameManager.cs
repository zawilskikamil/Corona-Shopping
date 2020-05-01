using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerFoodPoints = 0;
    public static GameManager instance = null;
    public Canvas canvas;

    public Text levelText;
    public GameObject levelImage;
    public GameObject infoTextImage;

    private int level = 1;
    private bool playersTurn = true;
    private bool canPlayerMove = true;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        print(instance.playersTurn);

        instance.ReasignVarible();
        instance.InitGame();
    }

    void ReasignVarible()
    {
        if (levelImage == null)
        {
            levelImage = GameObject.Find("LevelImage");
        }
        if (infoTextImage == null)
        {
            infoTextImage = GameObject.Find("InfoTextImage");
        }

        if (levelText == null)
        {
            levelText = GameObject.Find("LevelText").GetComponent<Text>();
        }
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
        StartCoroutine(BackToMainMenu());
    }

    private IEnumerator BackToMainMenu()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Menu", LoadSceneMode.Single);

        
    }

    public void LevelComplete()
    {
        if (false)
        {
            levelText.text = "Shoping complete!";
            levelImage.SetActive(true);
            enabled = false;
        }
        else
        {
            StartCoroutine(ShowInfoText());
        }
        
    }


    private IEnumerator ShowInfoText()
    {
        infoTextImage.SetActive(true);
        yield return new WaitForSeconds(1);
        infoTextImage.SetActive(false);
    }

    public bool CanPlayerMove()
    {
        return canPlayerMove;
    }
}