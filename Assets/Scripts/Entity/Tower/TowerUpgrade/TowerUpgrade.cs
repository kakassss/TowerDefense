public class TowerUpgrade : ITowerUpgrade
{
    public void IncreaseHealthStage(SelectedTowerReceiver selectedTowerReceiver)
    {
        selectedTowerReceiver.SelectedTower.Health.
            IncreaseHealthStage(selectedTowerReceiver.SelectedTower.HealthStages);
    }
}