using UnityEngine;

public class Grid<T>
{
    public T Slot;
    public float CellSize;
    public Vector3 OriginPosition;
}

public class Cell
{
    public Vector3 Position;
    public bool IsFull;
    
    public Cell(Vector3 position, bool isfull)
    {
        Position = position;
        IsFull = isfull;
    }
}
