
public class GameCurrency
{
    public int coins { get; private set; }
    
    public GameCurrency(int startingCoins = 100)
    {
        coins = startingCoins;
    }
    
    public void AddCoins(int amount)
    {
        if (amount > 0)
        {
            coins += amount;
        }
    }
    
    public bool SpendCoins(int amount)
    {
        if (amount <= 0) return false;
        
        if (coins >= amount)
        {
            coins -= amount;
            return true;
        }
        
        return false;
    }
    
    public bool HasEnoughCoins(int amount)
    {
        return coins >= amount;
    }
    
    public int GetCurrentCoins()
    {
        return coins;
    }
}
