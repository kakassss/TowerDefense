using UnityEngine;

public class Grid<T>
{
    public T Slot;
    public float CellSize;
    public Vector3 OriginPosition;
}

public class Cell<T>
{
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
