using UnityEngine;
using SimpleInputNamespace;
using InputActionManager;

namespace Gameplay.Vehicle
{
    public class VehicleInputManager : MonoBehaviour
    {
        public static VehicleInputManager Instance;

        [SerializeField] private SteeringWheel steeringWheel;
        [SerializeField] private InputManager inputManager;

        private VehicleController _vehicleController;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }
        private void Start()
        {
            _vehicleController = GetComponent<VehicleController>();

            inputManager.OnMove += OnMoveEvent;
            inputManager.OnBrake += OnBrakeEvent;
        }

        private void OnMoveEvent(int moveVal)
        {
            _vehicleController.AccelerationBehaviour(inputManager.VerticalAxis);
            print($"OnMove : {moveVal}");
        }

        private void OnBrakeEvent(bool wasBrakePressed)
        {
            if (wasBrakePressed)
                _vehicleController.BrakeBehaviour();
            else
                _vehicleController.UnBrakeBehaviour();
        }

        private void FixedUpdate()
        {
            _vehicleController.SteerBehaviour(steeringWheel.Value);

            _vehicleController.UpdateAllWheels();
        }
    }
}