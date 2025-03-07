using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public bool solid;
    public bool enemy;
    private SpriteRenderer _spriteRenderer;
    private Color _defaultColor;
    public MonsterType monsterType;
    public bool move = false;
    bool coroutineStarted = false;
    

    public enum MonsterType
    {
        None,
        Red,
        Green,
        Purple
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor = _spriteRenderer.color;
    }

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    public void Update()
    {
        switch (monsterType)
        {
            case MonsterType.Red:
                {
                    _spriteRenderer.color = Color.red;
                }
                break;
            case MonsterType.Green:
                {
                    _spriteRenderer.color = Color.green;
                }
                break;
            case MonsterType.Purple:
                {
                    _spriteRenderer.color = Color.magenta;
                }
                break;
            default:
                {
                    _spriteRenderer.color = Color.white;
                }
                break;
        }
        if (enemy == true)
        {
            if (coroutineStarted == false)
            {
                StartCoroutine(Co_Wait());
            }
        }

    }

    public IEnumerator Co_Wait()
    {
        coroutineStarted = true;
        yield return new WaitForSeconds(1.31f);
        move = true;
        coroutineStarted = false;
    }


}
