using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    public Tilemap floorTilemap;
    public Tilemap wallTilemap;

    public GameObject[] itemTiles;

    private List<Vector3> gridPositions = new List<Vector3>();

    private void Start()
    {
        SetupScene(1);
    }

    public void SetupScene(int level)
    {
        InitialiseList();
        LayoutObjectAtRandom(itemTiles, 1, 20);
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
                    if (currentWallTile == null)
                    {
                        gridPositions.Add(new Vector3(row, col, 0f));
                    }
                }
            }
        }
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
        print(objectCount);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            print(tileChoice);

            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }
}
