using UnityEngine;

public class CheckPointBehaviour : MonoBehaviour
{
    public static event System.Action OnAnyPointReached;

    private void OnTriggerEnter(Collider collider)
    {
        OnAnyPointReached.Invoke();
        this.gameObject.SetActive(false);
    }
}