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
    public CellPowerEnum CellPowerEnum;
    
    
    public Cell(int gridX, int gridZ, bool isfull,CellPowerEnum cellPowerEnum = CellPowerEnum.Normal)
    {
        GridX = gridX;
        GridZ = gridZ;
        IsFull = isfull;
        CellPowerEnum = cellPowerEnum;
    }
}

public enum CellPowerEnum
{
    Normal,
    Heavy,
    Fire,
    Ice,
    Light,
    Dark,
}



