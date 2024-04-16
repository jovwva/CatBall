using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{    
    [SerializeField] private float rotationSpeedZ;
    private bool _isRotating;
    private void OnMouseDown()
    {
        _isRotating = true;
    }
    private void OnMouseUp()
    {
        _isRotating = false;
    }

    private void Update() 
    {
        if(_isRotating)
            this.transform.rotation *= Quaternion.Euler(0f, 0f, rotationSpeedZ *Time.deltaTime);
    }
}
