using Database;
using Database.Stages;
using Gameplay.Field;
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

        private int currentStage = 0;

        #endregion

        #region PROPERTIES

        public GameplayField GameplayField => gameplayField;
        public StagesDatabase StagesDatabase => MainDatabases.Instance.StagesDatabase;
        private StageData CurrentStage { get; set; }
        private float CurrentTime { get; set; }

        #endregion

        #region METHODS

        public override void Initialzie()
        {
            base.Initialzie();
            if (gameplayField == null)
                gameplayField = Instantiate(gameplayFieldPrefab);
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

        #region HANDLERS

        private void HandleTimeTicked()
        {
            CurrentTime += Time.deltaTime;
        }

        #endregion

        #endregion
    }
}
