
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
    }

    #endregion
}
