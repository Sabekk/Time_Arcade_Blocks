using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Database.Stages
{
    [Serializable]
    public class StageElementData
    {
        #region VARIABLES

        [SerializeField] private float scale;
        [SerializeField] private float pointReward;

        #endregion

        #region PROPERTIES

        public float Scale => scale;
        public float PointReward => pointReward;

        #endregion

        #region METHODS

        #endregion
    }
}