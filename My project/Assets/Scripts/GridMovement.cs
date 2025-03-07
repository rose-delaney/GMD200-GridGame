using UnityEngine;

public class GridMovement : MonoBehaviour 
{
    public GridManager grid;
    public Vector2Int gridPos = Vector2Int.zero;
    public Transform playerLocation;

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
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 5.0f * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPos) > 0.01f)
            return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
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
            grid.GetTile(x, y).enemy = false;
            grid.GetTile(x, y).monsterType = GridTile.MonsterType.None;
            grid.GetTile(x, y).GetComponent<SpriteRenderer>().color = Color.white;
            grid.GetTile(x, y).solid = false;
        }
    }
}
