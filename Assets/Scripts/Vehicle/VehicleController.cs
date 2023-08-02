using UnityEngine;

namespace Gameplay.Vehicle
{
    public class VehicleController : MonoBehaviour, IVehicle
    {
        [Header("VehicleParameters")]
        [field: SerializeField] public float MotorForce = 1000.0f;
        [field: SerializeField] public float BreakForce { get; private set; } = 800.0f;
        [field: SerializeField] public float MaxSteetAngle { get; private set; } = 30.0f;

        [SerializeField] private GameObject CenterOfMass;
        [SerializeField] private SimpleInputNamespace.SteeringWheel steeringWheel;

        [Header("WheelColliders")]

        [SerializeField] WheelCollider FrontLeft_WheelCollider;
        [SerializeField] WheelCollider FrontRight_WheelCollider;
        [SerializeField] WheelCollider RearLeft_WheelCollider;
        [SerializeField] WheelCollider RearRight_WheelCollider;

        [Header("WheelTransforms")]
        [SerializeField] Transform FrontLeft_Wheel;
        [SerializeField] Transform FrontRight_Wheel;
        [SerializeField] Transform RearLeft_Wheel;
        [SerializeField] Transform RearRight_Wheel;

        private float _steerInput;
        private float _accelerationInput;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.centerOfMass = CenterOfMass.transform.localPosition;
        }

        private void Update()
        {
            CalculateInput();
        }

        private void FixedUpdate()
        {
            SteerBehaviour();
            AccelerationBehaviour();

            UpdateWheel(FrontLeft_WheelCollider, FrontLeft_Wheel);
            UpdateWheel(FrontRight_WheelCollider, FrontRight_Wheel);
            UpdateWheel(RearLeft_WheelCollider, RearLeft_Wheel);
            UpdateWheel(RearRight_WheelCollider, RearRight_Wheel);
        }

        public void SetInputData(Vector3 Vertical)
        {
            CalculateInput();
        }

        private void CalculateInput()
        {
            _accelerationInput = Input.GetAxis("Vertical");

            //Steeting input retrieved from steering wheel class
            _steerInput = steeringWheel.Value;

            if (Input.GetKey(KeyCode.Space)) BrakeBehaviour();
            if (Input.GetKeyUp(KeyCode.Space)) UnBrakeBehaviour();
        }

        void SteerBehaviour()
        {
            float steerAngle = MaxSteetAngle * _steerInput;
            FrontLeft_WheelCollider.steerAngle = steerAngle;
            FrontRight_WheelCollider.steerAngle = steerAngle;
        }

        void AccelerationBehaviour()
        {
            RearLeft_WheelCollider.motorTorque = _accelerationInput * (MotorForce / 2.0f);
            RearRight_WheelCollider.motorTorque = _accelerationInput * (MotorForce / 2.0f);
        }

        void BrakeBehaviour()
        {
            FrontLeft_WheelCollider.brakeTorque = BreakForce;
            FrontRight_WheelCollider.brakeTorque = BreakForce;
            RearLeft_WheelCollider.brakeTorque = BreakForce;
            RearRight_WheelCollider.brakeTorque = BreakForce;
        }

        void UnBrakeBehaviour()
        {
            RearLeft_WheelCollider.brakeTorque = 0;
            RearRight_WheelCollider.brakeTorque = 0;
            FrontLeft_WheelCollider.brakeTorque = 0;
            FrontRight_WheelCollider.brakeTorque = 0;
        }

        private void UpdateWheel(WheelCollider wheelCollider, Transform wheelTransform)
        {
            Vector3 position;
            Quaternion rotation;
            wheelCollider.GetWorldPose(out position, out rotation);

            wheelTransform.rotation = rotation * Quaternion.Euler(0, 0, 0);
        }

        public float GetSpeed() => _rigidbody.velocity.magnitude;
    }
}