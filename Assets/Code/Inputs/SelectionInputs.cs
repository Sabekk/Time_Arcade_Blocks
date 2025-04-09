using Gameplay.Inputs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Inputs.Selection
{
    public class SelectionInputs : InputsBase, InputBinds.ISelectionActions
    {
        #region ACTIONS

        public event Action<Vector2> OnClick;

        #endregion

        #region CONSTRUCTORS

        public SelectionInputs(InputBinds binds) : base(binds)
        {
            Binds.Selection.SetCallbacks(this);
        }

        #endregion

        #region METHODS

        public override void Enable()
        {
            Binds.Selection.Enable();
        }

        public override void Disable()
        {
            Binds.Selection.Disable();
        }

        public void OnSelectAction(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Vector2 screenPosition = Mouse.current.position.ReadValue();
                OnClick?.Invoke(screenPosition);
            }
        }

        #endregion
    }
}