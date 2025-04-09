using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Field
{
    public class GameplayField : MonoBehaviour
    {
        #region VARIABLES

        [SerializeField] private GameplayField_Slot[] slots;

        private List<GameplayField_Slot> slotsTmp = new();

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        public Transform GetRandomFreeSlotPlace()
        {
            slotsTmp.Clear();
            for (int i = 0; i < slots.Length; i++)
            {
                if (!slots[i].IsReserved)
                    slotsTmp.Add(slots[i]);

            }

            if (slotsTmp.Count <= 0)
                return null;

            int randomIndex = Random.Range(0, slotsTmp.Count);
            return slotsTmp[randomIndex].transform;
        }

        #endregion
    }
}
