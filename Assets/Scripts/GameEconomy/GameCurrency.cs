using System;

public class GameCurrency
{
    public Action OnCurrencyChanged;
    public int Coins { get; private set; }
    
    public GameCurrency(int startingCoins = 10000)
    {
        Coins = startingCoins;
    }
    
    public void AddCoins(int amount)
    {
        if (amount > 0)
        {
            Coins += amount;
            OnCurrencyChanged?.Invoke();
        }
    }
    
    public bool SpendCoins(int amount)
    {
        if (amount <= 0) return false;
        
        if (Coins >= amount)
        {
            Coins -= amount;
            OnCurrencyChanged?.Invoke();
            return true;
        }
        
        return false;
    }
    
    public bool HasEnoughCoins(int amount)
    {
        return Coins >= amount;
    }
    
    public int GetCurrentCoins()
    {
        return Coins;
    }
}
