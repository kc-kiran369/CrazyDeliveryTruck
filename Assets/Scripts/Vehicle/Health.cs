using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public uint HealthValue { get; private set; } = 100;

    public void Reset() => HealthValue = 100;

    public void ReduceHealth(int value)
    {
        HealthValue -= Convert.ToUInt32(value);
    }
}