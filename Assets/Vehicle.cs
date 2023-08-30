using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private static Vehicle singleton;
    public static Vehicle GetInstance()
    {
        if (singleton == null)
            singleton = FindObjectOfType<Vehicle>();
        return singleton;
    }

    public Transform GetTransform => transform;
}
