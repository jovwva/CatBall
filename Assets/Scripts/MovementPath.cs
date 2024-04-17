using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{   
    [SerializeField] private Transform[] _pathElements; 
    [SerializeField] private float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    void Start()
    {
        journeyLength = Vector3.Distance(_pathElements[0].position, _pathElements[1].position);

    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(_pathElements[0].position, _pathElements[1].position, fracJourney);

        if (fracJourney >= 1f)
        {
            Vector3 temp = _pathElements[0].position;
            _pathElements[0].position = _pathElements[1].position;
            _pathElements[1].position = temp;
            startTime = Time.time;
        }
    }
}
