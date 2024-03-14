using UnityEngine;

class DragTransform : MonoBehaviour
{
    public PlatformDrag platformDrag;
    private Vector3 mousePosition;

    private Vector3 GetMousePosition() => Camera.main.WorldToScreenPoint(transform.position);

    private void OnMouseDown()
    {
        platformDrag.StartDrag();
        mousePosition = Input.mousePosition - GetMousePosition();
    }
    private void OnMouseUp()
    {
        platformDrag.EndDrag();
    }

    private void OnMouseDrag() => 
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition  -mousePosition);
}