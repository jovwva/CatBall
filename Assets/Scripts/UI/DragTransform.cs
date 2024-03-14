using UnityEngine;

class DragTransform : MonoBehaviour
{
    public PlatformDrag platformDrag;
    private Vector3 mousePosition;
    private bool isDraging = true;
    

    private void Start() => OnMouseDown();

    private Vector3 GetMousePosition() => Camera.main.WorldToScreenPoint(transform.position);

    private void OnMouseDown()
    {
        isDraging = true;
        platformDrag.StartDrag();
        mousePosition = Input.mousePosition - GetMousePosition();
    }
    private void OnMouseUp()
    {
        isDraging = false;
        platformDrag.EndDrag();
    }

    // private void OnMouseDrag() => 
    //     transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition  -mousePosition);

    private void Update()
    {
        if (!isDraging) return;

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition  -mousePosition);
    }
}