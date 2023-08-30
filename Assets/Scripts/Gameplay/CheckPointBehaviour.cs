using UnityEngine;
using System;

public class CheckPointBehaviour : MonoBehaviour
{
    public static event Action OnAnyPointReached;

    private void OnTriggerEnter(Collider collider)
    {
        OnAnyPointReached.Invoke();
        this.gameObject.SetActive(false);
    }
}