using UnityEngine;
using System;

public class VehicleCollision : MonoBehaviour
{
    Gameplay.Vehicle.VehicleController _vehicleController;
    Health _health;

    private void Awake()
    {
        _vehicleController = GetComponent<Gameplay.Vehicle.VehicleController>();
        _health = GetComponent<Health>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        float speed = _vehicleController.GetSpeed();

        Debug.Log($"Speed during collision : {speed}");

        if (speed > 5) TakeDamage(speed);
    }

    void TakeDamage(float speedDuringCollision)
    {
        _health.ReduceHealth(Convert.ToInt32(speedDuringCollision) * 2);
    }
}
