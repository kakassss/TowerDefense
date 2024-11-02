using System.Collections.Generic;
using UnityEngine;

public class Grid<T>
{
    public T Slot;
    public float CellSize;
    public Vector3 OriginPosition;
}


public class Cell<T>
{
    public int GridX;
    public int GridZ;
    public bool IsFull;
    public T Entity;
    public CellPower DefaultCellPower;
    public List<CellPower> CellPowerEnumList;
    
    public Cell(int gridX, int gridZ, bool isfull, CellPower defaultCellPower)
    {
        GridX = gridX;
        GridZ = gridZ;
        IsFull = isfull;
        DefaultCellPower = defaultCellPower;
        
        //Default Power 
        CellPowerEnumList = new List<CellPower> { DefaultCellPower };
    }
}

public enum CellPower
{
    Normal,
    Heavy,
    Fire,
    Ice,
    Light,
    Dark,
}