using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialIcon : MonoBehaviour
{
    /*
    1) проверить проходили ли уровень+
    2) Активировать подсветку+
    3) ждать нажатия
    4) Активировать анимашку
    5) ждать нажатия 
    6) Активировать подсветку
    */

    public int levelID;
    public GameObject sparks;


    private void Start()
    {
        if (SaveSystem.Instance.GetLevelData(levelID).starCount == 0){
            sparks.SetActive(true);
        }
    }

    public void ActivateTrigger(int id){
        switch(id) {
            case 0:

                break;
            case 1:

                break;
        }
    }
}
