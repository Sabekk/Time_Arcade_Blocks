using Database.Stages;
using UnityEngine;

namespace Database
{
    [CreateAssetMenu(menuName = "Database/MainDatabases", fileName = "MainDatabases")]
    public class MainDatabases : ScriptableSingleton<MainDatabases>
    {
        #region VARIABLES

        [SerializeField] private StagesDatabase stagesDatabase;

        #endregion

        #region PROPERTIES

        public new static MainDatabases Instance => GetInstance("Singletons/MainDatabases");

        public StagesDatabase StagesDatabase => stagesDatabase;

        #endregion

        #region METHODS

        #endregion
    }
}