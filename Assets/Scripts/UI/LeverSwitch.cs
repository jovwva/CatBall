using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    [SerializeField] private Transform _leverTransform;
    [SerializeField] private SpriteRenderer _spriteHandle;
    [SerializeField] private BallFactory _ballFactory;
    private bool _isLeverOpen = false;

    
    private void Start(){
        _spriteHandle.color = Color.red;
    }
    private void OnMouseDown(){
        _isLeverOpen = !_isLeverOpen;
        _ballFactory.ChangeState(_isLeverOpen);
        _leverTransform.transform.rotation = Quaternion.Euler(0, 0, -1 * _leverTransform.eulerAngles.z);
        _spriteHandle.color = _isLeverOpen ? Color.green : Color.red;
    }
}
