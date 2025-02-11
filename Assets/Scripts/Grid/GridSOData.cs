using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridSOData", menuName = "Grid/GridSOData")]
public class GridSOData : ScriptableObject
{
    public int width;
    public int height;
    
    [SerializeField] private List<bool> serializedOccupied = new List<bool>();

    public bool[,] isOccupied;

    public void InitializeGrid()
    {
        isOccupied = new bool[width, height];

        if (serializedOccupied.Count == width * height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    isOccupied[x, y] = serializedOccupied[y * width + x];
                }
            }
        }
        else
        {
            serializedOccupied = new List<bool>(new bool[width * height]);
        }
    }
        
    public void SaveGrid()
    {
        serializedOccupied.Clear();

        // 2D diziyi listeye çevirerek kaydet
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                serializedOccupied.Add(isOccupied[x, y]);
            }
        }
    }
}
