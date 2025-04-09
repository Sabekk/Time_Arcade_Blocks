using Database;
using Database.Stages;
using Gameplay.Score;
using System;

namespace Gameplay.Stages
{
    public class StageManager : GameplayManager<StageManager>, IGameOverListener, IResetListener
    {
        #region ACTIONS

        public event Action OnStageChanged;

        #endregion

        #region VARIABLES

        private int currentStageId;

        #endregion

        #region PROPERTIES

        public StageData CurrentStageData { get; set; }
        private StagesDatabase StagesDatabase => MainDatabases.Instance.StagesDatabase;

        #endregion

        #region METHODS

        public override void Initialzie()
        {
            base.Initialzie();
            ResetState();
        }

        public void OnGameOver()
        {
            DetachEvents();
        }

        public void OnGameReset()
        {
            AttachEvents();
            ResetState();
        }

        protected override void AttachEvents()
        {
            base.AttachEvents();
            if (ScoreManager.Instance)
                ScoreManager.Instance.OnScoreChanged += HandleScoreChanged;
        }

        protected override void DetachEvents()
        {
            base.DetachEvents();
            if (ScoreManager.Instance)
                ScoreManager.Instance.OnScoreChanged -= HandleScoreChanged;
        }

        private void TryChangeStageToNext()
        {
            int nextStage = currentStageId + 1;
            if (StagesDatabase.ContainStageId(nextStage))
            {
                currentStageId = nextStage;
                CurrentStageData = StagesDatabase.TryGetNextStage(currentStageId);
                OnStageChanged?.Invoke();
            }
            else
                DetachEvents();
        }

        private void ResetState()
        {
            currentStageId = 0;
            CurrentStageData = StagesDatabase.TryGetNextStage(currentStageId);
            OnStageChanged?.Invoke();
        }

        #region HANDLERS

        private void HandleScoreChanged()
        {
            if (ScoreManager.Instance.CurrentScore >= CurrentStageData.PointThreshold)
                TryChangeStageToNext();
        }

        #endregion

        #endregion
    }
}