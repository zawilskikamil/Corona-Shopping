using System.Collections;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
    public float moveTime = 0.5f;
    public LayerMask blockingLayer;

    private Rigidbody2D rb2D;               
    private float inverseMoveTime;            
    protected bool isMoving = false;
    private Animator animator;

    protected virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inverseMoveTime = 1f / moveTime;
    }

    public bool Move(MovingObject.Direction direction)
    {
        float x = 0;
        float y = 0;
        string trigger = "";

        switch (direction)
        {
            case Direction.UP:
                y = 1;
                trigger = "PlayerGoUp";
                break;
            case Direction.DOWN:
                y = -1;
                trigger = "PlayerGoDown";
                break;
            case Direction.LEFT:
                x = -1;
                trigger = "PlayerGoLeft";
                break;
            case Direction.RIGHT:
                x = 1;
                trigger = "PlayerGoRight";
                break;
        }

        bool moving = Move(x, y);
        if (moving)
        {
            animator.SetTrigger(trigger);
        }
        return moving;
    }

    public bool Move(float xDir, float yDir)
    {
        if (isMoving)
        {
            return false;
        }

        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        RaycastHit2D hit = Physics2D.Linecast(start, end, blockingLayer);


        if (hit.transform != null)
        {
            return false;
        }

        isMoving = true;
        StartCoroutine(SmoothMovement(end));
        return true;
    }

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
            rb2D.MovePosition(newPostion);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
        isMoving = false;
    }

    public enum Direction
    {
        LEFT, RIGHT, UP, DOWN
    }
}
