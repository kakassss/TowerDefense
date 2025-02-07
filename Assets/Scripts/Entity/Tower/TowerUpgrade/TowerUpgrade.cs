using System;

public class TowerUpgrade : ITowerUpgrade
{
    public Action OnIncreaseHealth;
    public void IncreaseHealthStage(SelectedTowerReceiver selectedTowerReceiver)
    {
        selectedTowerReceiver.SelectedTower.TowerHealth.
            IncreaseHealthStage(selectedTowerReceiver.SelectedTower.HealthStages);
        
        OnIncreaseHealth?.Invoke();
    }
}