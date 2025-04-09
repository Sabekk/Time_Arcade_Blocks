using Gameplay.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Selection
{
    public class SelectionManager : GameplayManager<SelectionManager>
    {
        #region VARIABLES

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        protected override void AttachEvents()
        {
            base.AttachEvents();
            if (InputManager.Instance)
                InputManager.Instance.SelectionInputs.OnClick += HandleClick;
        }

        protected override void DetachEvents()
        {
            base.DetachEvents();
            if (InputManager.Instance)
                InputManager.Instance.SelectionInputs.OnClick -= HandleClick;
        }


        #region HANDLERS

        void HandleClick(Vector2 screenPosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                if (hit.collider.TryGetComponent(out IClickable clickable))
                    clickable.OnClick();
        }

        #endregion

        #endregion
    }
}
