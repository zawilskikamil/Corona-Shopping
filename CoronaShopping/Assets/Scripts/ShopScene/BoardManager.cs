using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine.Tilemaps;
using System;

public class BoardManager : MonoBehaviour
{
    public static BoardManager instance = null;

    public Tilemap floorTilemap;
    public Tilemap wallTilemap;
    public Grid grid;

    public GameObject[] itemTiles;
    public int minItem = 1;
    public int maxItem = 2;

    public GameObject[] npc;
    public int minNpc = 1;
    public int maxNpc = 2;

    private readonly List<Vector3> gridPositions = new List<Vector3>();

    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        SetupScene(PointsManager.instance.currentLevel);
    }

    public void SetupScene(int level)
    {
        InitialiseList();
        LayoutObjectAtRandom(itemTiles, minItem * level, maxItem * level);
        LayoutObjectAtRandom(npc, minNpc * level, maxNpc * level);
    }

    void InitialiseList()
    {
        gridPositions.Clear();
        BoundsInt size = floorTilemap.cellBounds;
        for (int col = size.yMin; col <= size.yMax; col++)
        {
            for (int row = size.xMin; row <= size.xMax; row++)
            {
                TileBase currentFloorTile = floorTilemap.GetTile(new Vector3Int(row, col, 0));
                if (currentFloorTile != null)
                {
                    TileBase currentWallTile = wallTilemap.GetTile(new Vector3Int(row, col, 0));
                    if (currentWallTile != null)
                    {
                        continue;
                    }
                    Collider2D hitColliders = Physics2D.OverlapCircle(new Vector2(row, col), 0);
                    if (hitColliders != null)
                    {
                        continue;
                    }
                    gridPositions.Add(new Vector3(row, col, 0f));
                }
            }
        }
    }

    internal Vector3 GetPositionOf(MovingObject movingObject)
    {
        Vector3Int lPos = grid.WorldToCell(movingObject.transform.position);
        return lPos;
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }
}
