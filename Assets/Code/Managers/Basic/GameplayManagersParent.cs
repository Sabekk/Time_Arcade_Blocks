
using Gameplay.Inputs;
using Gameplay.Selection;
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
    }

    #endregion
}
