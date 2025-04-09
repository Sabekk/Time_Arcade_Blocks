using Gameplay.Field;
using Gameplay.Props;
using Gameplay.PureGameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Spawning
{
    public class SpawnManager : GameplayManager<SpawnManager>
    {
        #region VARIABLES

        [Header("Prefabs")]
        [SerializeField] private GameplayField gameplayFieldPrefab;
        [SerializeField] private ClickableCube cubePrefab;

        #endregion

        #region PROPERTIES

        private GameManager gameManager => GameManager.Instance;
        private GameplayField GameplayField => gameManager.GameplayField;

        #endregion

        #region METHODS

        public ClickableCube TrySpawnNewCube()
        {
            Transform randomPlace = GameplayField.GetRandomFreeSlotPlace();

            if (randomPlace == null)
                return null;

            ClickableCube cube = Instantiate(cubePrefab, randomPlace);
            cube.Initialize(Random.ColorHSV(), 1);

            return cube;
        }

        #endregion
    }
}