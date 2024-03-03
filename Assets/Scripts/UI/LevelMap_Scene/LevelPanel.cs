using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    [Header("Динамически заполняемые данные")]
    [SerializeField] private SaveSystem saveSystem;
    [SerializeField] private List<LevelButton> levelButtonList;
    [Space]
    [Header("Статические данные")]
    [SerializeField] private GameObject levelButtonPref;

    // private void Awake() {
    //     levelButtonList = new List<LevelButton>();

    //     foreach(Transform go in transform) {
    //         levelButtonList.Add(go.GetComponent<LevelButton>());
    //     }
    // }

    private void Start() {
        for (int i = 0; i < saveSystem.playerData.levelsDataList.Count; i++) {
            if (i >= levelButtonList.Count) {
                Debug.Log($"Непредусмотренный урвоень Level_{i}");
                LevelButton newLevelButton = Instantiate(levelButtonPref, transform).GetComponent<LevelButton>();
                levelButtonList.Add(newLevelButton);
            }

            levelButtonList[i].InitButton(saveSystem.LoadLevelData(i), this);
        }   
    }

    public void LoadLevel(int levelID)
    {
        SceneManager.LoadSceneAsync($"Level_{levelID}");
    }


}
