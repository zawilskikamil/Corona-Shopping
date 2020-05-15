using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
using UnityEngine.Tilemaps;

public class NPCMoving : MovingObject
{
    public GameObject[] viruses;
    public Grid grid;
    public Tilemap floorTilemap;

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
        int randomIndex = UnityEngine.Random.Range(0, 4);
        if (randomIndex == 0)
        {
            Move(Direction.LEFT);
        }
        if (randomIndex == 1)
        {
            Move(Direction.RIGHT);
        }
        if (randomIndex == 2)
        {
            Cough();
        }
        canMove = false;
        StartCoroutine(ToggleCanMove());
    }

    private void Cough()
    {
        animator.SetTrigger("Cough");
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
        Vector3 currentPosition = GetCurrentPosition();
        GameObject virus = viruses[Random.Range(0, viruses.Length)];
        Instantiate(virus, currentPosition, Quaternion.identity);
    }

    private Vector3 GetCurrentPosition()
    {
        Vector3Int lPos = grid.WorldToCell(transform.position);
        Debug.Log("name : " + floorTilemap.GetTile(lPos).name + " & position : " + lPos);
        return lPos;
    }
}
