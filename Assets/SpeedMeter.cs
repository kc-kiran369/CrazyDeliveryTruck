using UnityEngine;
using Gameplay.Vehicle;
public class SpeedMeter : MonoBehaviour
{
    public float MinAngle, MaxAngle;
    public float MaxSpeed = 100;

    public VehicleController vehicle;
    [SerializeField] RectTransform MeterPin;
    [SerializeField] TMPro.TMP_Text SpeedText;

    private void Update()
    {
        UpdateSpeedMeter(vehicle.GetSpeed());
    }

    private void UpdateSpeedMeter(float speed)
    {
        speed = vehicle.GetSpeed() * 3.6f;
        SpeedText.text = $"{(int)speed} km/h";
        MeterPin.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(MinAngle, MaxAngle, speed / MaxSpeed));
    }
}
