using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputAsset _inputAsset;

    private void Awake()
    {
        _inputAsset = new();
        _inputAsset.Vehicle.Move.performed += MovePerformed;
        _inputAsset.Vehicle.Look.performed += LookPerformed;
        _inputAsset.Vehicle.Break.performed += BrakePerformed;
    }

    private void MovePerformed(InputAction.CallbackContext context)
    {
        print($"Move Performed : {context.ReadValue<Vector2>()}");
    }
    private void LookPerformed(InputAction.CallbackContext context)
    {
        
    }
    private void BrakePerformed(InputAction.CallbackContext context)
    {
        print($"Brake Performed");
    }
    private void OnEnable() { _inputAsset.Enable(); }

    private void OnDisable() { _inputAsset.Disable(); }
}