using UnityEngine;

public class PopupOpener : MonoBehaviour
{
    public GameObject popupPrefab;

    public Canvas m_canvas;

    protected void Start()
    {
        OpenPopup();
    }

    public virtual void OpenPopup()
    {
        var popup = Instantiate(popupPrefab) as GameObject;
        popup.SetActive(true);
        popup.transform.localScale = Vector3.zero;
        popup.transform.SetParent(m_canvas.transform, false);
    }
}