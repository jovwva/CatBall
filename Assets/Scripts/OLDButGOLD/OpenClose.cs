using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private StartManager startManager;
    private bool flag = true;

    private void Start() {
        startManager = this.gameObject.GetComponent<StartManager>();
    }
    void OnMouseDown()
    {
        Switch();
    }

    public void Switch()
    {
        if (flag)
            Open();
        else
            Close();
    }
    private void Open()
    {
        door.gameObject.SetActive(false);
        startManager.enabled = true;
        flag = false;
    }
    
    private void Close()
    {
        door.gameObject.SetActive(true);
        startManager.enabled = false;
        flag = true;
    }
}
