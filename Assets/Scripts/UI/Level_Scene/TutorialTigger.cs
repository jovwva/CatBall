using UnityEngine;

public class TutorialTigger : MonoBehaviour
{
    private bool isListen = false;
    [SerializeField] private TutorialIcon tutorialIcon;

    public void ChangeState(bool newState) => isListen = newState;

    private void OnMouseDown()
    {
        if (!isListen) return;

        tutorialIcon.ActivateTrigger(3);
        ChangeState(false);
    }
}
