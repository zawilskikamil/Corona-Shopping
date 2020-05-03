using UnityEngine;
using System.Collections;

public class NPCMoving : MovingObject
{
    private bool canMove = true; 

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        if (isMoving || !canMove)
        {
            return;
        }
        int randomIndex = Random.Range(0, 4);
        if (randomIndex == 1)
        {
            Move(Direction.LEFT);
        }
        if (randomIndex == 0)
        {
            Move(Direction.RIGHT);
        }
        canMove = false;
        StartCoroutine(ToggleCanMove());
    }

    protected IEnumerator ToggleCanMove()
    {
        yield return new WaitForSeconds(1);
        canMove = !canMove;
    }
}
