using System;

public class TowerUpgrade : ITowerUpgrade
{
    public Action OnIncreaseHealth;
    public void IncreaseHealthStage(SelectedTowerReceiver selectedTowerReceiver)
    {
        selectedTowerReceiver.SelectedTower.Health.
            IncreaseHealthStage(selectedTowerReceiver.SelectedTower.HealthStages);
        
        OnIncreaseHealth?.Invoke();
    }
}