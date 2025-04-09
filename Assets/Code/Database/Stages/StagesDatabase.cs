using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Database.Stages
{
    [CreateAssetMenu(menuName = "Database/StagesDatabase", fileName = "StagesDatabase")]

    public class StagesDatabase : ScriptableObject
    {
        #region VARIABLES

        [SerializeField] private StageData[] stages;

        #endregion

        #region PROPERTIES

        public StageData[] Stages => stages;

        #endregion

        #region METHODS



        #endregion
    }
}