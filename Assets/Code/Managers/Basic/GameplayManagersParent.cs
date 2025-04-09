
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

    protected override void SetManagers()
    {
        managers.Add(TimeManager.Instance);
        managers.Add(InputManager.Instance);
        managers.Add(SelectionManager.Instance);
        managers.Add(GameManager.Instance);
        managers.Add(SpawnManager.Instance);
        managers.Add(ScoreManager.Instance);
        managers.Add(StageManager.Instance);
    }

    #endregion
}
