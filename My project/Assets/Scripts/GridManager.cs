using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using static GridTile;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GridManager : MonoBehaviour
{
    public GridTile tilePrefab;
    public int numRows = 3;
    public int numCols = 3;
    public Vector2 tileSize = Vector2.one;
    public Vector2 padding = new Vector2(0.1f, 0.1f);
    public GridTile enemyPlacement;
    public MonsterType spawningMonsterType;
    public bool greenCanSpawn = false;
    public bool purpleCanSpawn = false;
    public int secondsWait = 5;
    public GameObject player;

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
                _tiles.Add(tile);
            }
        }
        player = GameObject.Find("Player");
        StartCoroutine(Co_SpawnTimer());
        StartCoroutine(Co_DiffScaler());
    }
    public GridTile GetTile(int col, int row)
    {
        int index = row * numCols + col;
        return _tiles[index];
    }

    private void EnemySpawner()
    {
        int rand1 = Random.Range(0, 5);
        int rand2 = Random.Range(0, 5);
        enemyPlacement = GetTile(rand1, rand2);
        enemySpawning();
        enemyPlacement.monsterType = spawningMonsterType;
        enemyPlacement.enemy = true;
        StartCoroutine(Co_SpawnTimer());
    }

    public IEnumerator Co_SpawnTimer()
    {
        yield return new WaitForSeconds(secondsWait);
        EnemySpawner();
    }

    public IEnumerator Co_DiffScaler()
    {
        yield return new WaitForSeconds(15);
        secondsWait = 4;
        yield return new WaitForSeconds(15);
        greenCanSpawn = true;
        yield return new WaitForSeconds(30);
        purpleCanSpawn = true;
        yield return new WaitForSeconds(15);
        secondsWait = 3;
    }

    public void enemySpawning()
    {
        if (greenCanSpawn == true)
        {
            if (purpleCanSpawn == true)
            {
                int rand = Random.Range(0, 10);
                switch (rand)
                {
                    case 0:
                    case 1:
                        {
                            spawningMonsterType = MonsterType.Red;
                        }
                        break;
                    case 2:
                    case 3:
                    case 4:
                        {
                            spawningMonsterType = MonsterType.Green;
                        }
                        break;
                    default:
                        {
                            spawningMonsterType = MonsterType.Purple;
                        }
                        break;
                }
            }
            else
            {
                int rand = Random.Range(0, 1);
                if (rand == 0)
                    spawningMonsterType = MonsterType.Red;
                else
                    spawningMonsterType = MonsterType.Green;
            }
        }
        else
            spawningMonsterType = MonsterType.Red;
    }

    private void Update()
    {
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                GridTile selectedTile = GetTile(row, col);
                if (selectedTile.move == true)
                {
                    MonsterType type = selectedTile.monsterType;
                    int xmove = MovementX(selectedTile.monsterType, player.GetComponent<GridMovement>().gridPos.x, row);
                    int ymove = MovementY(selectedTile.monsterType, player.GetComponent<GridMovement>().gridPos.y, col);
                    if ((xmove + row) < 0 || 4 < (xmove + row))
                    {
                        xmove = 0;
                    }
                    if ((ymove + col) < 0 || 4 < (ymove + row))
                    {
                        ymove = 0;
                    }
                    if (GetTile((xmove + row), (xmove + col)).enemy == true)
                    {
                        xmove = 0;
                        ymove = 0;
                    }
                    selectedTile.enemy = false;
                    selectedTile.monsterType = MonsterType.None;
                    GetTile((xmove + row), (xmove + col)).enemy = true;
                    GetTile((xmove + row), (xmove + col)).monsterType = type;
                    selectedTile.move = false;
                }
            }
        }
    }

    public int MovementX(MonsterType type, int playerX, int monsterX)
    {
        int rand = Random.Range(-1, 2);
        switch (type)
        {
            case MonsterType.Red:
                return rand;
            case MonsterType.Purple:
                if (rand == 0)
                    rand = -1;
                return rand;
            default:
                if (playerX < monsterX)
                    return -1;
                if (playerX > monsterX)
                    return 1;
                else
                    return 0;
        }
    }

    public int MovementY(MonsterType type, int playerY, int monsterY)
    {
        int rand = Random.Range(-1, 2);
        switch (type)
        {
            case MonsterType.Red:
                return rand;
            case MonsterType.Purple:
                if (rand == 0)
                    rand = -1;
                return rand;
            default:
                if (playerY < monsterY)
                    return -1;
                if (playerY > monsterY)
                    return 1;
                else
                    return 0;
        }
    }
}
