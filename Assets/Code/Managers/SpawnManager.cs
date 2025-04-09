using Database.Stages;
using Gameplay.Field;
using Gameplay.Props;
using Gameplay.PureGameplay;
using Gameplay.Stages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Spawning
{
    public class SpawnManager : GameplayManager<SpawnManager>
    {
        #region VARIABLES

        [Header("Prefabs")]
        [SerializeField] private ClickableCube cubePrefab;

        #endregion

        #region PROPERTIES

        private GameManager GameManager => GameManager.Instance;
        private StageManager StageManager => StageManager.Instance;
        private GameplayField GameplayField => GameManager.GameplayField;
        private StageData CurrentStage => StageManager.CurrentStageData;

        #endregion

        #region METHODS

        public ClickableCube TrySpawnNewCube()
        {
            Transform randomPlace = GameplayField.GetRandomFreeSlotPlace();
            if (randomPlace == null)
                return null;

            StageElementData randomElement = CurrentStage.GetRandomElement();
            if (randomElement == null)
                return null;

            ClickableCube cube = Instantiate(cubePrefab);

            cube.Initialize(Random.ColorHSV(), randomElement.Scale, randomElement.PointReward);

            cube.transform.SetParent(randomPlace);
            cube.transform.localPosition = Vector3.zero;

            return cube;
        }

        #endregion
    }
}