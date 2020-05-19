using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
using UnityEngine.Tilemaps;

public class NPCMoving : MovingObject
{
    public GameObject[] viruses;
    public AudioClip coughSound;
    public AudioClip coughSound2;

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
        int randomIndex = UnityEngine.Random.Range(0, 5);
        switch (randomIndex)
        {
            case 0:
                Move(Direction.DOWN);
                break;
            case 1:
                Move(Direction.UP);
                break;
            case 2:
                Move(Direction.LEFT);
                break;
            case 3:
                Move(Direction.RIGHT);
                break;
            case 4:
                Cough();
                break;
        }
       
        canMove = false;
        StartCoroutine(ToggleCanMove());
    }

    private void Cough()
    {
        animator.SetTrigger("Cough");
        SoundManager.instance.RandomizeSfx(coughSound, coughSound2);
        StartCoroutine(CreateVirus());
    }

    protected IEnumerator ToggleCanMove()
    {
        yield return new WaitForSeconds(1);
        canMove = !canMove;
    }

    protected IEnumerator CreateVirus()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 currentPosition = BoardManager.instance.GetPositionOf(this);
        GameObject virus = viruses[Random.Range(0, viruses.Length)];
        Instantiate(virus, currentPosition, Quaternion.identity);
    }
}
