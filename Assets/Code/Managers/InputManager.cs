using Gameplay.Inputs.Selection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Inputs
{
    public class InputManager : GameplayManager<InputManager>
    {
        #region VARIABLES

        static InputBinds _controll;

        #endregion

        #region PROPERTIES

        public SelectionInputs SelectionInputs { get; private set; }

        public static InputBinds Input
        {
            get
            {
                if (_controll == null)
                    _controll = new InputBinds();
                return _controll;
            }
        }

        #endregion

        #region UNITY_METHODS

        private void OnEnable() => Input.Enable();

        private void OnDisable() => Input.Disable();

        #endregion

        #region METHODS

        public override void Initialzie()
        {
            base.Initialzie();
            SelectionInputs = new(Input);
        }

        #endregion
    }
}