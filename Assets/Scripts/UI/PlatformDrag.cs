using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDrag : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Collider2D anyCollider;

    private Color halfAlphaColor = new Color(1f, 1f, 1f, .5f);
    public void StartDrag() {
        anyCollider.enabled = false;
        sprite.color = halfAlphaColor;
    }
    public void EndDrag() {
        anyCollider.enabled = true;
        sprite.color = Color.white;
    }
}
