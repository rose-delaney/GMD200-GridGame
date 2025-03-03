using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;

public class GridManager : MonoBehaviour
{
    public GridTile tilePrefab;
    public int numRows = 3;
    public int numCols = 3;
    public Vector2 tileSize = Vector2.one;
    public Vector2 padding = new Vector2(0.1f, 0.1f);
    public GridTile enemyPlacement;

    public List<GridTile> _tiles = new List<GridTile>();
    private void Awake()
    {
        _tiles.Capacity = numRows * numCols;

        for(int row = 0; row < numRows; row++)
        {
            for(int col = 0; col < numCols; col++)
            {
                Vector2 pos = new Vector2(col * (tileSize.x + padding.x), row * (tileSize.y + padding.y));
                GridTile tile = Instantiate(tilePrefab,pos,Quaternion.identity,transform);
                int rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    tile.solid = true;
                    tile.enemy = false;
                    tile.GetComponent<SpriteRenderer>().color = Color.black;
                }
                _tiles.Add(tile);
            }
        }
        StartCoroutine(Co_SpawnTimer());
    }
    public GridTile GetTile(int col, int row)
    {
        int index = row * numCols + col;
        return _tiles[index];
    }

    private void EnemySpawner()
    {
        int rand1 = Random.Range(0, 4);
        int rand2 = Random.Range(0, 4);
        enemyPlacement = GetTile(rand1, rand2);
        enemyPlacement.GetComponent<SpriteRenderer>().color = Color.red;
        enemyPlacement.enemy = true;
    }

    public IEnumerator Co_SpawnTimer()
    {
        yield return new WaitForSeconds(3);
        EnemySpawner();
    }
}
