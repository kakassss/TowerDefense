using System.Collections.Generic;
using UnityEngine;

public class Grid<T>
{
    public T Slot;
    public float CellSize;
    public Vector3 OriginPosition;
}

public class Cell
{
    public int GridIndexX; // Using for building system, getting grid at this index
    public int GridIndexZ; // Using for building system, getting grid at this index
    public bool IsFull;
    
    
    public string Name; // Only for testing 
    public float Power;
    public BaseTower Entity; // Gameobject tutmak için yapmıstın şimdilik boş duruyor
    public ElementType DefaultCellPower;// Currently no feature
    public List<ElementType> CellPowerEnumList;// Currently no feature
    
    public Cell(int gridIndexX, int gridIndexZ, bool isFull, ElementType defaultCellPower)
    {
        GridIndexX = gridIndexX;
        GridIndexZ = gridIndexZ;
        IsFull = isFull;
        Name = "Cell At" + gridIndexX + "-" + gridIndexZ;
        
        DefaultCellPower = defaultCellPower;
        
        //Default Power 
        CellPowerEnumList = new List<ElementType> { DefaultCellPower };
    }
}