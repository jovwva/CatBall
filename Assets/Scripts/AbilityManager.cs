using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class AbilityManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    
    [SerializeField] private GameObject abilityPrefabes;
    [SerializeField] private GameObject buttonObj;
    [SerializeField] private TMP_Text textMeshPro;
    [SerializeField] private int abilityCounter = 0;
    [SerializeField] private float abilityRotaion = 0;
    public bool buttonPressed;
    private GameObject abilityObj;
    private Vector3 point;

    [SerializeField] private ScrollRect _scrollRect;
 
    private void Start() 
    {
        textMeshPro = this.gameObject.transform.GetChild(1).GetComponent<TMP_Text>();
        textMeshPro.text = abilityCounter.ToString();
        OffObject();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        CreateAbility();
    }
    
    public void OnPointerUp(PointerEventData eventData)
    { 
        abilityObj.GetComponent<DragTransform>().dragging = false;
        OffObject();
        _scrollRect.enabled = true;
        UpdateText();
    }
    
    public void CreateAbility()
    {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        point = pz;
        
        if (abilityRotaion != 0)
        {
            abilityObj = Instantiate(abilityPrefabes, point, Quaternion.Euler(0,0,abilityRotaion));
        }
        else
        {
            abilityObj = Instantiate(abilityPrefabes, point, Quaternion.identity);
        }
        abilityObj.GetComponent<DragTransform>().dragging = true;
        _scrollRect.enabled = false;
        abilityCounter--;
    }

    private void UpdateText()
    {
        textMeshPro.text = abilityCounter.ToString();
    }

    private void OffObject()
    {
    if (abilityCounter <= 0)
        buttonObj.SetActive(false);
    }
}
