using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LevelsMap()
    {
        SceneManager.LoadScene("LevelsMap");
    }

    public void NextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void Restart()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
