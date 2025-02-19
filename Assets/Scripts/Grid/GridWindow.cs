using UnityEditor;
using UnityEngine;

public class GridWindow : EditorWindow
{
    private GridSOData gridData;
    
    [MenuItem("Tools/Grid Editor")]
    public static void OpenWindow()
    {
        GetWindow<GridWindow>("Grid Editor");
    }

    private void OnGUI()
    {
        gridData = (GridSOData)EditorGUILayout.ObjectField("Grid Data", gridData, typeof(GridSOData), false);

        if (gridData == null) return;
        
        if (gridData.isOccupied == null)
        {
            Debug.LogError("gridData.isOccupied is null");
            gridData.isOccupied = new bool[gridData.Width, gridData.Height]; 
        }
        
        for (int y = 0; y < gridData.Height; y++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int x = 0; x < gridData.Width; x++)
            {
                gridData.isOccupied[x, y] = EditorGUILayout.Toggle(gridData.isOccupied[x, y]);
            }
            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Save Grid"))
        {
            EditorUtility.SetDirty(gridData);
            AssetDatabase.SaveAssets();
        }
    }
}
