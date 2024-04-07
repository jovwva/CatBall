using UnityEngine;
using UnityEngine.UI;

public class BackGroundHolder : MonoBehaviour
{
#region Field
    [SerializeField] private RawImage ornamentRI;
    [SerializeField] private float _x, _y;
    
#endregion

#region MonoBehaviour
    
    private void Start()
    {
        ChangeColor();
        ChangeShape();

        AssortmentBroker.ColorChanged += ChangeColor;
        AssortmentBroker.ShapeChanged += ChangeShape;
    }

    private void Update()
    {
        ornamentRI.uvRect = new Rect(ornamentRI.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, ornamentRI.uvRect.size);
    }

    void OnDestroy()
    {
        AssortmentBroker.ColorChanged -= ChangeColor;
        AssortmentBroker.ShapeChanged -= ChangeShape;
    }
    
#endregion

    private void ChangeColor() => Camera.main.backgroundColor = SaveSystem.Instance.GetBackColor();
    private void ChangeShape() => ornamentRI.texture          = SaveSystem.Instance.GetBackShape();
}