using UnityEngine;

public class BoundsCheck
{
    private float camW;
    private float camH;

    private Transform objectTR;

    public BoundsCheck(Transform objectTR)
    {
        this.objectTR = objectTR;

        camH = Camera.main.orthographicSize;
        camW = camH * Camera.main.aspect;
    }

    public void CheckBound()
    {
        Vector3 pos = objectTR.position;

        if (pos.x > camW)
        {
            pos.x = camW;
        }
        if (pos.x < -camW)
        {
            pos.x = -camW;
        }

        if (pos.y > camH)
        {
            pos.y = camH;
        }
        if (pos.y < -camH)
        {
            pos.y = -camH;
        }

        objectTR.position = pos;
    }
}
