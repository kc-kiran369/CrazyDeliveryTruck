using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attached to the Check Point Parent object which contains all the transforms for check points that player should reach to complete the level

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointBehaviour CheckPointBehaviour;

    [field: SerializeField] public uint TotalCheckPoints { get; private set; }
    [field: SerializeField] public uint ReachedCheckPoints { get; private set; } = 0;

    private void Awake()
    {
        TotalCheckPoints = (uint)transform.childCount;
        CheckPointBehaviour.OnAnyPointReached += OnAnyPointReached;
    }

    private void OnAnyPointReached()
    {
        ReachedCheckPoints++;

        if (ReachedCheckPoints >= TotalCheckPoints)
        {
            print("Level Complete");
        }
    }
}