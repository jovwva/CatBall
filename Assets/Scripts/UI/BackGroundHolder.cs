using UnityEngine;
using UnityEngine.UI;

public class BackGroundHolder : MonoBehaviour
{
#region Field
        [Header("Тестовые данные")]
        [SerializeField] private bool isTestRun = false;
    
        [SerializeField] private ItemColorSO  testColorItem;
        [SerializeField] private ItemShapeSO  testShapeItem;
        [Space]
        [SerializeField] private RawImage ornamentRI;
        [SerializeField] private float _x, _y;
    
#endregion

#region MonoBehaviour
    
    private void Start()
    {
        ChangeColor(isTestRun ? testColorItem.color : SaveSystem.Instance.GetBackColor());
        ChangeShape(isTestRun ? testShapeItem.shapeTexture : SaveSystem.Instance.GetBackShape());
    }

    private void Update()
    {
        ornamentRI.uvRect = new Rect(ornamentRI.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, ornamentRI.uvRect.size);
    }
    
#endregion

    private void ChangeColor(Color color) => Camera.main.backgroundColor    = color;
    private void ChangeShape(Texture texture) => ornamentRI.texture         = texture;
}