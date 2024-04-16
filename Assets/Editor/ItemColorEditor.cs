using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemColorSO))]
public class ItemColorEditor : Editor
{
    ItemColorSO itemColorSO;

    private void OnEnable()
    {
        itemColorSO = target as ItemColorSO;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(itemColorSO.icon == null)
        {
            return;
        }

        //Get icon
        Texture2D sprite = AssetPreview
            .GetAssetPreview(itemColorSO.icon);
        //Icon size
        GUILayout.Label("",
            GUILayout.Height(120), GUILayout.Width(120));
        //Draw icon
        GUI.DrawTexture(
            GUILayoutUtility.GetLastRect(), sprite);
    }
}
