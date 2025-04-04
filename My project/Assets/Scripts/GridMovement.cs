using System.Collections;
using UnityEngine;

public class GridMovement : MonoBehaviour 
{
    public GridManager grid;
    public Vector2Int gridPos = Vector2Int.zero;
    public Transform playerLocation;
    public UIManager userInterface;
    public bool isInvulnerable = false;

    private void Awake()
    {
        playerLocation = gameObject.transform.Find("Head");
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.RightArrow) && gridPos.x < grid.numCols - 1 && !grid.GetTile(gridPos.x + 1, gridPos.y).solid)
        {
            gridPos.x++;
            playerLocation.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && gridPos.x > 0 && !grid.GetTile(gridPos.x-1, gridPos.y).solid)
        {
            gridPos.x--;
            playerLocation.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && gridPos.y < grid.numRows - 1 && !grid.GetTile(gridPos.x, gridPos.y + 1).solid)
        {
            gridPos.y++;
            playerLocation.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && gridPos.y > 0 && !grid.GetTile(gridPos.x, gridPos.y - 1).solid)
        {
            gridPos.y--;
            playerLocation.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        Vector3 targetPos = grid.GetTile(gridPos.x, gridPos.y).transform.position;
        transform.position = targetPos;
        if (Vector3.Distance(transform.position, targetPos) > 0.01f)
            return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (grid.GetTile(gridPos.x, gridPos.y).enemy)
        {
            if (isInvulnerable == false)
            {
                StartCoroutine(Co_EnemyHit());
            }
        }
    }

    public IEnumerator Co_EnemyHit()
    {
        userInterface.LoseHealth();
        isInvulnerable = true;
        yield return new WaitForSeconds(3);
        isInvulnerable = false;
    }

    public void Attack()
    {
        int x = gridPos.x;
        int y = gridPos.y;

        if (playerLocation.transform.rotation == Quaternion.Euler(new Vector3(0, 0, 270)))
        {
            x = gridPos.x + 1;
        }
        if (playerLocation.transform.rotation == Quaternion.Euler(new Vector3(0, 0, 90)))
        {
            x = gridPos.x - 1;
        }
        if (playerLocation.transform.rotation == Quaternion.Euler(new Vector3(0, 0, 0)))
        {
            y = gridPos.y + 1;
        }
        if (playerLocation.transform.rotation == Quaternion.Euler(new Vector3(0, 0, 180)))
        {
            y = gridPos.y - 1;
        }
        if (grid.GetTile(x, y).enemy)
        {
            int scoreAdd;
            Debug.Log("test 1");
            switch (grid.GetTile(x, y).monsterType)
            {
                case GridTile.MonsterType.Red:
                    scoreAdd = 10;
                    break;
                case GridTile.MonsterType.Purple:
                    scoreAdd = 20;
                    break;
                default:
                    scoreAdd = 25;
                    break;
            }
            Debug.Log("test tuah");
            userInterface.GainScore(scoreAdd);
            grid.GetTile(x, y).enemy = false;
            grid.GetTile(x, y).monsterType = GridTile.MonsterType.None;
            grid.GetTile(x, y).GetComponent<SpriteRenderer>().color = Color.white;
            grid.GetTile(x, y).solid = false;
        }
    }
}
