using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Gameplay.Score;
using Gameplay.PureGameplay;

namespace Gameplay.HUD
{
    public class GameplayHUD : MonoBehaviour
    {
        #region VARIABLES

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Slider slider;

        #endregion

        #region PROPERTIES

        private ScoreManager ScoreManager => ScoreManager.Instance;

        #endregion

        #region UNITY_METHODS

        private void Start()
        {
            Initialize();
            AttachEvents();
        }

        private void OnDestroy()
        {
            DetachEvents();
        }

        #endregion

        #region METHODS

        private void Initialize()
        {
            scoreText.SetText("Score");
            slider.value = 0;
            slider.maxValue = 1;
        }

        private void AttachEvents()
        {
            if (ScoreManager)
            {
                ScoreManager.OnScoreChanged += HandleScoreChanged;
                ScoreManager.OnThresholdChanged += HandleThresholdChanged;
            }
        }

        private void DetachEvents()
        {
            if (ScoreManager)
            {
                ScoreManager.OnScoreChanged -= HandleScoreChanged;
                ScoreManager.OnThresholdChanged -= HandleThresholdChanged;
            }
        }

        private void RefreshScore()
        {
            scoreText.SetText(ScoreManager.CurrentScore.ToString());
            slider.value = ScoreManager.CurrentScore;
        }

        private void RefreshThreshold()
        {
            slider.maxValue = ScoreManager.ThresholdScore;
        }

        #region UI

        public void Restart()
        {
            CurrentGameManager.Instance.ForceRestart();
        }

        public void Exit()
        {
            Application.Quit();
        }

        #endregion

        #region HANDLERS

        private void HandleScoreChanged()
        {
            RefreshScore();
        }

        private void HandleThresholdChanged()
        {
            RefreshThreshold();
        }

        #endregion

        #endregion
    }
}