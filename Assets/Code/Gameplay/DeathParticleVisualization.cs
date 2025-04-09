using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticleVisualization : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private ParticleSystem particle;

    #endregion

    #region PROPERTIES

    #endregion

    #region UNITY_METHODS

    void OnParticleSystemStopped()
    {
        Destroy(gameObject);
    }

    #endregion

    #region METHODS

    public void PlayDeath(Color color)
    {
        particle.startColor = color;
        particle.Play();
    }

    #endregion
}
