using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public GridTile tilePrefab;
    public int numRows = 3;
    public int numCols = 3;
    public Vector2 tileSize = Vector2.one;
    public Vector2 padding = new Vector2(0.1f, 0.1f);

    private List<GridTile> _tiles = new List<GridTile>();
    private void Awake()
    {
        _tiles.Capacity = numRows * numCols;

        for(int row = 0; row < numRows; row++)
        {
            for(int col = 0; col < numCols; col++)
            {
                Vector2 pos = new Vector2(col * (tileSize.x + padding.x), row * (tileSize.y + padding.y));
                GridTile tile = Instantiate(tilePrefab,pos,Quaternion.identity,transform);
                _tiles.Add(tile);
            }
        }
    }
    public GridTile GetTile(int col, int row)
    {
        int index = row * numCols + col;
        return _tiles[index];
    }
}
