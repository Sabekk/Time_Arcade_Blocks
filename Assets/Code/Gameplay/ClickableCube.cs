using Gameplay.PureGameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Props
{
    public class ClickableCube : MonoBehaviour, IClickable
    {
        #region ACTION

        public static event Action<float> OnClicked;

        #endregion

        #region VARIABLES

        [SerializeField] private Renderer rend;
        [SerializeField] private DeathParticleVisualization particleOnDeath;

        private float reward;

        #endregion

        #region PROPERTIES

        #endregion

        #region UNITY_METHODS

        private void Awake()
        {
            if (rend == null)
                rend = GetComponent<Renderer>();
        }

        private void OnDestroy()
        {
            DetachEvents();
        }

        #endregion

        #region METHODS

        public void Initialize(Color color, float scale, float reward)
        {
            rend.material.color = color;
            transform.localScale = Vector3.one * scale;
            this.reward = reward;
            AttachEvents();
        }

        public void OnClick()
        {
            DestroyObject(true);
        }

        private void DestroyObject(bool publishReward)
        {
            if (particleOnDeath != null)
            {
                DeathParticleVisualization particle = Instantiate(particleOnDeath, transform);
                particle.transform.SetParent(null);
                particle.PlayDeath(rend.material.color);
            }
            if (publishReward)
                OnClicked?.Invoke(reward);

            Destroy(gameObject);
        }

        private void AttachEvents()
        {
            if (CurrentGameManager.Instance)
            {
                CurrentGameManager.Instance.OnPublishGameOver += HandleGameOver;
                CurrentGameManager.Instance.OnPublicGameRestart += HandleGameRestart;
            }
        }

        private void DetachEvents()
        {
            if (CurrentGameManager.Instance)
            {
                CurrentGameManager.Instance.OnPublishGameOver -= HandleGameOver;
                CurrentGameManager.Instance.OnPublicGameRestart -= HandleGameRestart;
            }
        }

        #region HANDLERS

        private void HandleGameOver()
        {
            DestroyObject(false);
        }

        private void HandleGameRestart()
        {
            DestroyObject(false);
        }

        #endregion

        #endregion
    }
}