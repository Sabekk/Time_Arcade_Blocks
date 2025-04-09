using System;

namespace Gameplay.Timing
{
    public class TimeManager : GameplayManager<TimeManager>
    {
        #region ACTIONS

        public event Action OnTimeTicked;

        #endregion

        #region UNITY_METHODS

        private void Update()
        {
            if (Initialized == false)
                return;

            OnTimeTicked?.Invoke();
        }

        #endregion

    }
}
