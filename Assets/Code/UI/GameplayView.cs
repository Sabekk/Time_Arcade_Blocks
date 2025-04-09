using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Gameplay.Score;
using Gameplay.PureGameplay;
using System;
using System.Text;

namespace Gameplay.HUD
{
    public class GameplayView : MonoBehaviour
    {
        #region VARIABLES

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI scoreEndText;
        [SerializeField] private Slider slider;

        [SerializeField] private GameStateView gameplayView;
        [SerializeField] private GameStateView gameOverView;

        StringBuilder builder = new();

        #endregion

        #region PROPERTIES

        private ScoreManager ScoreManager => ScoreManager.Instance;
        private CurrentGameManager CurrentGameManager => CurrentGameManager.Instance;

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
            RefreshView();
        }

        private void AttachEvents()
        {
            if (ScoreManager)
            {
                ScoreManager.OnScoreChanged += HandleScoreChanged;
                ScoreManager.OnThresholdChanged += HandleThresholdChanged;
            }

            if (CurrentGameManager)
            {
                CurrentGameManager.OnPublishGameOver += HandleGameOver;
                CurrentGameManager.OnPublicGameRestart += HandleGameRestart;
            }
        }

        private void DetachEvents()
        {
            if (ScoreManager)
            {
                ScoreManager.OnScoreChanged -= HandleScoreChanged;
                ScoreManager.OnThresholdChanged -= HandleThresholdChanged;
            }

            if (CurrentGameManager)
            {
                CurrentGameManager.OnPublishGameOver -= HandleGameOver;
                CurrentGameManager.OnPublicGameRestart -= HandleGameRestart;
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

        //TODO make gamestates
        private void RefreshView()
        {
            if (CurrentGameManager.IsGameOver)
            {
                gameplayView.SetState(false);
                gameOverView.SetState(true);

                RefreshGameOverView();
            }
            else
            {
                gameplayView.SetState(true);
                gameOverView.SetState(false);

                RefreshGameplayView();
            }
        }

        private void RefreshGameplayView()
        {
            RefreshScore();
            RefreshThreshold();
        }

        private void RefreshGameOverView()
        {
            if (builder == null)
                builder = new();
            builder.Clear();
            builder.AppendFormat("Score : {0}", ScoreManager.CurrentScore);
            scoreEndText.SetText(builder);
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

        private void HandleGameOver()
        {
            RefreshView();
        }

        private void HandleGameRestart()
        {
            RefreshView();
        }

        #endregion

        #endregion

        #region STRUCT

        [Serializable]
        public struct GameStateView
        {
            public GameObject[] stateObjects;

            public void SetState(bool state)
            {
                for (int i = 0; i < stateObjects.Length; i++)
                {
                    stateObjects[i].SetActive(state);
                }
            }
        }

        #endregion
    }
}