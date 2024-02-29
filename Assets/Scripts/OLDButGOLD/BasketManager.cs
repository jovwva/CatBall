using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BasketManager : MonoBehaviour
{
    public int star1;
    public int star2;
    public int star3;
    public int stars;
    public int numberOfBalls = 0;


    [SerializeField] private string colorTag;
    [SerializeField] private TMP_Text textMeshPro;
    [SerializeField] private Image _image;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == colorTag)
        {
            numberOfBalls++;
            UpdateCount();
            CheckNumberOfBalls();
        }
    }

    void CheckNumberOfBalls()
    {
        if (numberOfBalls > star1 && stars < 1)
        {stars++;}
            else if (numberOfBalls > star2 && stars < 2)
                {stars++;}
            else if (numberOfBalls > star3 && stars < 3)
                {stars++;}
    }

    private void UpdateCount()
    {
        _image.fillAmount = (float)numberOfBalls / star3;
        textMeshPro.text = numberOfBalls.ToString();
    }
}
