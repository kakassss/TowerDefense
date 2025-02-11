using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridSOData))]
public class GridEditorData : Editor
{
    private GridSOData gridData;
    private void OnEnable()
    {
        gridData = (GridSOData)target;

        if (gridData.isOccupied == null || gridData.isOccupied.GetLength(0) != gridData.width || gridData.isOccupied.GetLength(1) != gridData.height)
        {
            gridData.InitializeGrid();
        }
    }

        public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Grid Occupancy", EditorStyles.boldLabel);

        for (int y = 0; y < gridData.height; y++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int x = 0; x < gridData.width; x++)
            {
                if (gridData.isOccupied != null)
                {
                    gridData.isOccupied[x, y] = EditorGUILayout.Toggle(gridData.isOccupied[x, y], GUILayout.Width(20));
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Save Grid"))
        {
            gridData.SaveGrid();
            EditorUtility.SetDirty(gridData); // Değişiklikleri kaydet
            AssetDatabase.SaveAssets(); // Dosya olarak kaydet
        }
    }
}
