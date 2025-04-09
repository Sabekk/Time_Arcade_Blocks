using Gameplay.Props;
using Gameplay.Stages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Score
{
    public class ScoreManager : GameplayManager<ScoreManager>
    {
        #region ACTION

        public event Action OnScoreChanged;
        public event Action OnThresholdChanged;

        #endregion

        #region VARIABLES

        private float currentScore;
        private float thresholdScore;

        #endregion

        #region PROPERTIES

        public float CurrentScore => currentScore;
        private float ThresholdScore => thresholdScore;

        #endregion

        #region METHODS

        public override void LateInitialzie()
        {
            base.LateInitialzie();
            ResetScore();
            ResetThresholdToCurrentState();
        }

        protected override void AttachEvents()
        {
            base.AttachEvents();
            if (StageManager.Instance)
                StageManager.Instance.OnStageChanged += HandleStageChanged;

            ClickableCube.OnClicked += HandleCubeClicked;
        }

        protected override void DetachEvents()
        {
            base.DetachEvents();
            if (StageManager.Instance)
                StageManager.Instance.OnStageChanged -= HandleStageChanged;

            ClickableCube.OnClicked -= HandleCubeClicked;
        }

        public void AddToScore(float delta)
        {
            float lastScore = currentScore;
            currentScore += delta;

            if (lastScore != currentScore)
                OnScoreChanged?.Invoke();
        }

        public void ResetScore()
        {
            currentScore = 0;
            OnScoreChanged?.Invoke();
        }

        private void ResetThresholdToCurrentState()
        {
            if (StageManager.Instance)
                SetThreshold(StageManager.Instance.CurrentStageData.PointThreshold);
            else
            {
                SetThreshold(0);
                Debug.LogError("Missing stage data", this);
            }
        }

        private void SetThreshold(float delta)
        {
            if (thresholdScore != delta)
            {
                thresholdScore = delta;
                OnThresholdChanged?.Invoke();
            }
        }

        #region HANDLERS

        private void HandleCubeClicked(float reward)
        {
            AddToScore(reward);
        }

        private void HandleStageChanged()
        {
            ResetThresholdToCurrentState();
            ResetScore();
        }

        #endregion

        #endregion
    }
}