using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    private Transform leverTransform;
    private SpriteRenderer _spriteHandle;
    public bool leverIsOpen = false;
    void Start(){
        leverTransform = transform.GetChild(0);
        _spriteHandle = leverTransform.GetChild(1).GetComponent<SpriteRenderer>();
        _spriteHandle.color = Color.red;
    }
    void OnMouseDown(){
        leverIsOpen = !leverIsOpen;
        leverTransform.transform.rotation = Quaternion.Euler(0, 0, -1 * leverTransform.eulerAngles.z);
        if(leverIsOpen)
            _spriteHandle.color = Color.green;
        else
            _spriteHandle.color = Color.red;
    }
}
