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
    
    public Cell(bool isfull)
    {
        IsFull = isfull;
    }
}
