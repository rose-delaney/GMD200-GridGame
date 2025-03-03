using UnityEngine;

public class GridTile : MonoBehaviour
{
    public bool solid;
    private SpriteRenderer _spriteRenderer;
    private Color _defaultColor;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor = _spriteRenderer.color;
    }

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}
