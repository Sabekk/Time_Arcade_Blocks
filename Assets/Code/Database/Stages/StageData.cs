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

        [SerializeField] private StageElementData[] stageElements;
        [SerializeField] private float pointThreshold;
        [SerializeField] private float spawningSpeed;

        #endregion

        #region PROPERTIES

        public StageElementData[] StageElements => stageElements;
        public float PointThreshold => pointThreshold;
        public float SpawningSpeed => spawningSpeed;

        #endregion

        #region METHODS

        public StageElementData GetRandomElement()
        {
            if (StageElements == null || StageElements.Length == 0)
                return null;

            int randomIndex = UnityEngine.Random.Range(0, StageElements.Length);
            return StageElements[randomIndex];
        }

        #endregion
    }
}