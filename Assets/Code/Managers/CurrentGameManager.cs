using Gameplay.Field;
using Gameplay.Props;
using Gameplay.Spawning;
using Gameplay.Stages;
using Gameplay.Timing;
using System;
using UnityEngine;

namespace Gameplay.PureGameplay
{
    public class CurrentGameManager : GameplayManager<CurrentGameManager>, IGameOverListener, IResetListener
    {
        #region ACTIONS

        public event Action OnPublishGameOver;
        public event Action OnPublicGameRestart;

        #endregion

        #region VARIABLES

        [SerializeField] private GameplayField gameplayFieldPrefab;
        [SerializeField] private GameplayField gameplayField;

        #endregion

        #region PROPERTIES

        public GameplayField GameplayField => gameplayField;
        private float CurrentTime { get; set; }

        #endregion

        #region METHODS

        public override void Initialzie()
        {
            base.Initialzie();
            if (gameplayField == null)
                gameplayField = Instantiate(gameplayFieldPrefab);
        }

        public void ForceRestart()
        {
            ((GameplayManagersParent)ManagersParent.Instance).ResetGame();
        }

        public void OnGameOver()
        {
            OnPublishGameOver?.Invoke();
            DetachEvents();
        }

        public void OnGameReset()
        {
            CurrentTime = 0;
            AttachEvents();
            OnPublicGameRestart?.Invoke();
        }

        protected override void AttachEvents()
        {
            base.AttachEvents();
            if (TimeManager.Instance)
                TimeManager.Instance.OnTimeTicked += HandleTimeTicked;
        }

        protected override void DetachEvents()
        {
            base.DetachEvents();
            if (TimeManager.Instance)
                TimeManager.Instance.OnTimeTicked -= HandleTimeTicked;
        }

        private void TryAddCube()
        {
            if (SpawnManager.Instance == null)
                return;

            ClickableCube cube = SpawnManager.Instance.TrySpawnNewCube();

            if (cube == null)
            {
                ((GameplayManagersParent)ManagersParent.Instance).GameOver();
            }
        }

        #region HANDLERS

        private void HandleTimeTicked()
        {
            CurrentTime += Time.deltaTime;

            if (CurrentTime >= StageManager.Instance.CurrentStageData.SpawningSpeed)
            {
                TryAddCube();
                CurrentTime = 0;
            }
        }

        #endregion

        #endregion
    }
}
