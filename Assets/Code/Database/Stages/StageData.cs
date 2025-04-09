using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Database.Stages
{
    [Serializable]
    public class StageData
    {
        #region VARIABLES

        [SerializeReference] private StageElementData[] stageElements;
        [SerializeField] private float pointThreshold;
        [SerializeField] private float spawningSpeed;

        #endregion

        #region PROPERTIES

        public StageElementData[] StageElements => stageElements;
        public float PointThreshold => pointThreshold;
        public float SpawningSpeed => spawningSpeed;

        #endregion

        #region METHODS

        #endregion
    }
}