using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Field
{
    public class GameplayField_Slot : MonoBehaviour
    {
        #region VARIABLES

        #endregion

        #region PROPERTIES

        public bool IsReserved => transform.childCount > 0;

        #endregion

        #region METHODS

        #endregion
    }
}