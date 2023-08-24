using UnityEngine;

namespace Gameplay.Vehicle
{
    public class VehicleController : MonoBehaviour, IVehicle
    {
        public static VehicleController VehicleControllerInstance { get; private set; }

        [Header("VehicleParameters")]
        [field: SerializeField] public float MotorForce = 1000.0f;
        [field: SerializeField] public float BreakForce { get; private set; } = 800.0f;
        [field: SerializeField] public float MaxSteetAngle { get; private set; } = 30.0f;
        [field: SerializeField] public int MaxSpeed { get; private set; } = 10;

        [SerializeField] private GameObject CenterOfMass;

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

        private Rigidbody _rigidbody;

        private void Awake()
        {
            if (VehicleControllerInstance == null) VehicleControllerInstance = this;
            else Destroy(gameObject);
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.centerOfMass = CenterOfMass.transform.localPosition;
        }

        public void SteerBehaviour(float steeringWheelValue)
        {
            float steerAngle = MaxSteetAngle * steeringWheelValue;
            FrontLeft_WheelCollider.steerAngle = steerAngle;
            FrontRight_WheelCollider.steerAngle = steerAngle;
        }

        public void AccelerationBehaviour(float vertical)
        {
           // if (GetSpeed() > MaxSpeed) return;
            if (vertical == 0.0f)
            {
                RearLeft_WheelCollider.motorTorque = 0;
                RearRight_WheelCollider.motorTorque = 0;
            }
            else
            {
                RearLeft_WheelCollider.motorTorque = vertical * (MotorForce / 2.0f);
                RearRight_WheelCollider.motorTorque = vertical * (MotorForce / 2.0f);
            }
        }

        public void BrakeBehaviour()
        {
            FrontLeft_WheelCollider.brakeTorque = BreakForce;
            FrontRight_WheelCollider.brakeTorque = BreakForce;
            RearLeft_WheelCollider.brakeTorque = BreakForce;
            RearRight_WheelCollider.brakeTorque = BreakForce;
        }

        public void UnBrakeBehaviour()
        {
            RearLeft_WheelCollider.brakeTorque = 0;
            RearRight_WheelCollider.brakeTorque = 0;
            FrontLeft_WheelCollider.brakeTorque = 0;
            FrontRight_WheelCollider.brakeTorque = 0;
        }

        public void UpdateAllWheels()
        {
            UpdateWheel(FrontLeft_WheelCollider, FrontLeft_Wheel);
            UpdateWheel(FrontRight_WheelCollider, FrontRight_Wheel);
            UpdateWheel(RearLeft_WheelCollider, RearLeft_Wheel);
            UpdateWheel(RearRight_WheelCollider, RearRight_Wheel);
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