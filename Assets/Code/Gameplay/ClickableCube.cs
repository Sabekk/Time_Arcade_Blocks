using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Props
{
    public class ClickableCube : MonoBehaviour, IClickable
    {
        #region VARIABLES

        [SerializeField] private Renderer renderer;
        [SerializeField] private DeathParticleVisualization particleOnDeath;

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

        public void OnClick()
        {
            //Tmp

            if (particleOnDeath != null)
            {
                DeathParticleVisualization particle = Instantiate(particleOnDeath, transform);
                particle.transform.SetParent(null);
                particle.PlayDeath(renderer.material.color);
            }
            Destroy(gameObject);
        }

        #endregion
    }
}