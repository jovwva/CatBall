using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    [SerializeField] private Transform _leverTransform;
    [SerializeField] private SpriteRenderer _spriteHandle;
    [SerializeField] private BallFactory _ballFactory;
    
    private void Start(){
        _spriteHandle.color = Color.red;
    }
    private void OnMouseDown(){
        _ballFactory.SwitchLever();
        _leverTransform.transform.rotation = Quaternion.Euler(0, 0, -1 * _leverTransform.eulerAngles.z);
        if(_spriteHandle.color == Color.red)
            _spriteHandle.color = Color.green;
        else
            _spriteHandle.color = Color.red;
    }
}
