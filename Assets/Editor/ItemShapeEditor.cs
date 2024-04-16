using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemShapeSO))]
public class ItemShapeEditor : Editor
{
    ItemShapeSO itemShapeSO;

    private void OnEnable()
    {
        itemShapeSO = target as ItemShapeSO;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(itemShapeSO.icon == null)
        {
            return;
        }

        //Get icon
        Texture2D sprite = AssetPreview
            .GetAssetPreview(itemShapeSO.icon);
        //Icon size
        GUILayout.Label("",
            GUILayout.Height(120), GUILayout.Width(120));
        //Draw icon
        GUI.DrawTexture(
            GUILayoutUtility.GetLastRect(), sprite);
    }
}
