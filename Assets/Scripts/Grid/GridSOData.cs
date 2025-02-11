using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GridSOData", menuName = "Grid/GridSOData")]
public class GridSOData : ScriptableObject
{
    public int Width;
    public int Height;
    public float CellSize;
    public Vector3 OriginPosition;
    
    [SerializeField] private List<bool> serializedOccupied = new List<bool>();

    public bool[,] isOccupied;

    public List<bool> GetCells => serializedOccupied;

    public void InitializeGrid()
    {
        isOccupied = new bool[Width, Height];

        if (serializedOccupied.Count == Width * Height)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    isOccupied[x, y] = serializedOccupied[y * Width + x];
                }
            }
        }
        else
        {
            serializedOccupied = new List<bool>(new bool[Width * Height]);
        }
    }
        
    public void SaveGrid()
    {
        serializedOccupied.Clear();

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                serializedOccupied.Add(isOccupied[x, y]);
            }
        }
    }
}
