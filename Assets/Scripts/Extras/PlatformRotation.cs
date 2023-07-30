using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    public float Speed = 30;

    public bool ClockWise = true;

    private void Update()
    {
        transform.Rotate(0, (ClockWise ? 1.0f : -1.0f) * Time.deltaTime * Speed, 0);
    }
}