using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    [Header("Динамически заполняемые данные")]
    [SerializeField] private List<LevelButton> levelButtonList;
    [Space]
    [Header("Статические данные")]
    [SerializeField] private GameObject levelButtonPref;

    private void Start() {
        LevelData[] levelDataList = SaveSystem.Instance.GetLevelDataArray();
        
        for (int i = 0; i < levelDataList.Length; i++) {
            if (i >= levelButtonList.Count) {
                Debug.Log($"Непредусмотренный урвоень Level_{i}");
                // return;
                LevelButton newLevelButton = Instantiate(levelButtonPref, transform).GetComponent<LevelButton>();
                levelButtonList.Add(newLevelButton);
            }

            levelButtonList[i].InitButton(levelDataList[i], this);
        }   
    }

    public void LoadLevel(int levelID)
    {
        SceneManager.LoadSceneAsync($"Level_{levelID}");
    }
}
