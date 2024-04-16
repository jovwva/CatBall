using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMainCamera : MonoBehaviour
{
    private GameObject _camera;
    private Canvas _canvas;
    void Start()
    {
        _canvas = GetComponent<Canvas>();
        _camera = GameObject.FindWithTag("MainCamera");
        _canvas.worldCamera = _camera.GetComponent<Camera>();
    }

}
