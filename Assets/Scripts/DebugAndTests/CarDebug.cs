using UnityEngine;
using System;
using TMPro;

public class CarDebug : MonoBehaviour
{
    Gameplay.Vehicle.VehicleController vehicleController;
    [SerializeField] TMP_Text SpeedText;
    private void Awake()
    {
        vehicleController = GetComponent<Gameplay.Vehicle.VehicleController>();
    }

    private void Update()
    {
        SpeedText.text = $"Speed : {Convert.ToInt32(vehicleController.GetSpeed()).ToString()}m/s";
    }
}
