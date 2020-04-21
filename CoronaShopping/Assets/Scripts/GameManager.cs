using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerFoodPoints = 0;
    public static GameManager instance = null;

    private Text levelText;
    private GameObject levelImage;
    private int level = 1;
    private bool playersTurn = true;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);    
        DontDestroyOnLoad(gameObject);
        InitGame();
    }

    void OnLevelWasLoaded(int index)
    {
        level++;
        InitGame();
    }

    void InitGame()
    {
        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Game Over";
        levelImage.SetActive(false);
    }

    void Update()
    {
        GameObject.Find("ItemText").GetComponent<Text>().text = playerFoodPoints.ToString();
        if (playersTurn)
            return;

        StartCoroutine(MoveEnemies ());
    }

    public void GameOver()
    {

        levelImage.SetActive(true);
        enabled = false;
    }

    IEnumerator MoveEnemies()
    {
        yield return new WaitForSeconds(1);
        playersTurn = true;
    }
}