using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour
{
    public static MainManager instance = null;

    // Use this for initialization
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SayHello()
    {
        print("hello");
    }
}
