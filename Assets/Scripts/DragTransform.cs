using System.Collections;
using UnityEngine;
 
class DragTransform : MonoBehaviour
{
    public bool dragging = false;
    private float distance;
 


    void OnMouseDown()
    {
        dragging = true;
    }
 
    void OnMouseUp()
    {
        dragging = false;
    }
 
    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = 0;
            transform.position = rayPoint;
        }
    }
}