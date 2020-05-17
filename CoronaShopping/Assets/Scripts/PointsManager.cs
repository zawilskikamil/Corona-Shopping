using UnityEngine;
using System.Collections;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance = null;

    public int currentLevel = 1;
    public int points = 0;


    // Use this for initialization
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    public void SetupNewGame()
    {
        currentLevel = 1;
        points = 0;
    }

    public void LevelUp()
    {
        currentLevel++;
        print("Next level: " + currentLevel);
    }
}
