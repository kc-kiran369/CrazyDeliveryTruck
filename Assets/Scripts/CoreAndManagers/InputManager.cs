using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace InputActionManager
{
    public class InputManager : MonoBehaviour
    {
        private InputAsset _inputAsset;

        public event Action<int> OnMove;
        public event Action<bool> OnBrake;

        public float VerticalAxis { get; private set; }

        private void Awake()
        {
            _inputAsset = new();
            _inputAsset.Vehicle.Move.performed += MovePerformed;
            //_inputAsset.Vehicle.Look.performed += LookPerformed;
            _inputAsset.Vehicle.Break.performed += BrakePerformed;
        }

        private void MovePerformed(InputAction.CallbackContext context)
        {
            int moveVal = (int)context.ReadValue<Vector2>().y;
            VerticalAxis = moveVal;
            OnMove.Invoke(moveVal);
        }
        private void BrakePerformed(InputAction.CallbackContext context)
        {
            OnBrake(context.ReadValue<float>() == 1 ? true : false);
        }
        private void LookPerformed(InputAction.CallbackContext context)
        {

        }
        private void OnEnable() { _inputAsset.Enable(); }

        private void OnDisable() { _inputAsset.Disable(); }
    }
}