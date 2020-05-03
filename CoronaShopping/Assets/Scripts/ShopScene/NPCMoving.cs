using UnityEngine;
using System.Collections;

public class NPCMoving : MovingObject
{
    // Use this for initialization
    //void Start()
    //{
    //    base.Start();
    //}

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            return;
        }

        int randomIndex = Random.Range(0, 4);
        if (randomIndex == 1)
        {
            print(Move(Direction.LEFT));
        }
        if (randomIndex == 0)
        {
            print(Move(Direction.RIGHT));
        }
    }
}
