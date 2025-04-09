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

        [SerializeField] private Renderer renderer;
        [SerializeField] private DeathParticleVisualization particleOnDeath;

        private float reward;

        #endregion

        #region PROPERTIES

        #endregion

        #region UNITY_METHODS

        private void Awake()
        {
            if (renderer == null)
                renderer = GetComponent<Renderer>();
        }

        #endregion

        #region METHODS

        public void Initialize(Color color, float scale, float reward)
        {
            renderer.material.color = color;
            transform.localScale = Vector3.one * scale;
            this.reward = reward;
        }

        public void OnClick()
        {
            //Tmp

            if (particleOnDeath != null)
            {
                DeathParticleVisualization particle = Instantiate(particleOnDeath, transform);
                particle.transform.SetParent(null);
                particle.PlayDeath(renderer.material.color);
            }

            OnClicked?.Invoke(reward);

            Destroy(gameObject);
        }

        #endregion
    }
}