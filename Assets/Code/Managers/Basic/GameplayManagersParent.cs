using Gameplay.Inputs;
using Gameplay.PureGameplay;
using Gameplay.Score;
using Gameplay.Selection;
using Gameplay.Spawning;
using Gameplay.Stages;
using Gameplay.Timing;

public class GameplayManagersParent : ManagersParent
{
    #region VARIABLES

    #endregion

    #region PROPERTIES

    #endregion

    #region METHODS

    //Tmp. Move to global event if project will be developed 
    public void GameOver()
    {
        foreach (var manager in managers)
        {
            if (manager is IGameOverListener gameOverListener)
                gameOverListener.OnGameOver();
        }
    }

    public void ResetGame()
    {
        foreach (var manager in managers)
        {
            if (manager is IResetListener resetListener)
                resetListener.OnGameReset();
        }
    }

    protected override void SetManagers()
    {
        managers.Add(TimeManager.Instance);
        managers.Add(InputManager.Instance);
        managers.Add(SelectionManager.Instance);
        managers.Add(CurrentGameManager.Instance);
        managers.Add(SpawnManager.Instance);
        managers.Add(ScoreManager.Instance);
        managers.Add(StageManager.Instance);
    }

    #endregion
}
