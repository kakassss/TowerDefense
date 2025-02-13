using System.Collections.Generic;

public class Grid<T>
{
    public T Slot;
}

public class Cell
{
    public int GridIndexX; // Using for building system, getting grid at this index
    public int GridIndexZ; // Using for building system, getting grid at this index
    public bool IsFull;
    public bool IsEntityActive;
    
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