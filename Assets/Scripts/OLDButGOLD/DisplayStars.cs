using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayStars : MonoBehaviour
{
    [SerializeField] private GameObject[] starsObj;
    public void UpdateStars(int numberOfStars) 
    {
        if (numberOfStars > 0)
            starsObj[0].SetActive(true);
        if (numberOfStars > 1)
            starsObj[1].SetActive(true);
        if (numberOfStars > 2)
            starsObj[2].SetActive(true);
    }
}
