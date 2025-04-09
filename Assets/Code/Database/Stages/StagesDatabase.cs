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

        public bool ContainStageId(int stageId)
        {
            return Stages.Length - 1 >= stageId;
        }

        public StageData TryGetNextStage(int stageId)
        {
            if (ContainStageId(stageId) == false)
                return null;

            return Stages[stageId];
        }

        #endregion
    }
}