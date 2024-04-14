using UnityEngine;
using YG;

class DragTransform : MonoBehaviour
{
    public PlatformDrag platformDrag;
    private Vector3 mousePosition;
    private bool isDraging = true;

    private BoundsCheck boundsCheck;
    
    private void Awake()
    {
        boundsCheck = new BoundsCheck(transform);
    }

    private void Start() {
        OnMouseDown();
        if (YandexGame.EnvironmentData.deviceType != "desktop") {
            Debug.Log("ne desktop");
            transform.position = Vector3.zero;
        } 
    }

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

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
    private void LateUpdate()
    {
        if (!isDraging) return;

        boundsCheck.CheckBound();
    }
}