using UnityEngine;

public class ToolDraging : PlatformDrag
{
    [SerializeField] private SpriteRenderer spriteRend;
    [SerializeField] private Collider2D anyCollider;
    private Color halfAlphaColor = new Color(1f, 1f, 1f, .5f);

    public override void StartDrag()
    {
        anyCollider.enabled = false;
        spriteRend.color = halfAlphaColor;
        base.StartDrag();
    }
    public override void EndDrag()
    {
        anyCollider.enabled = true;
        spriteRend.color = Color.white;
        base.EndDrag();
    }
}