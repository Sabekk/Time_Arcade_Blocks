using Database;
using Database.Stages;
using Gameplay.Field;
using Gameplay.Props;
using Gameplay.Spawning;
using Gameplay.Stages;
using Gameplay.Timing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.PureGameplay
{
    public class GameManager : GameplayManager<GameManager>
    {
        #region ACTIONS

        public event Action OnGameOver;

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
                OnGameOver?.Invoke();
                //TODO show gameover window
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
