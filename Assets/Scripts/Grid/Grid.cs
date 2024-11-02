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
    public int GridIndexX;
    public int GridIndexZ;
    public bool IsFull;
    public T Entity; // Gameobject tutmak için yapmıstın şimdilik boş duruyor
    public CellPower DefaultCellPower;
    public List<CellPower> CellPowerEnumList;
    
    public Cell(int gridIndexX, int gridIndexZ, bool isfull, CellPower defaultCellPower)
    {
        GridIndexX = gridIndexX;
        GridIndexZ = gridIndexZ;
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