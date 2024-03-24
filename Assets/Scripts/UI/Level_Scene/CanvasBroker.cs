using System.Collections;
using UnityEngine;
using YG;

public class CanvasBroker : MonoBehaviour
{
    [Header("PlayPanel")]
    public PlayPanel        playPanel;
    public StarIndicator    starIndicator;
    public ToolSetter       toolSetter;
    [Space]
    [Header("PausePanel")]
    public PausePanel       pausePanel;
    [Space]
    [Header("ResultPanel")]
    public ResultPanel      resultPanel;

    public void InitAll(int id) {
        toolSetter.Init(id);
        pausePanel.Init(id);
    }

    public void ShowLevelResult(LevelData levelData) => StartCoroutine(ShowResult(levelData));
    public void ShowApproval(float value)            => starIndicator?.UpdateStarIndicator(value);
    
    IEnumerator ShowResult(LevelData levelData) {
        playPanel.HidePanel();
        resultPanel.Init(levelData);
        YandexGame.FullscreenShow();

        yield return new WaitForSeconds(1f);
        resultPanel.ShowPanel();
    }
}
