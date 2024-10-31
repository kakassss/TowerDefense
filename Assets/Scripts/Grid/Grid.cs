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
    
    
    public Cell(bool isfull,CellPowerEnum cellPowerEnum = CellPowerEnum.Normal)
    {
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

public struct GridEntity
{
    public int X;
    public int Z;
    public Vector3 Size;


    public GridEntity(int x, int z)
    {
        X = x;
        Z = z;
        Size = new Vector3(X, 0, Z);
    }
}
