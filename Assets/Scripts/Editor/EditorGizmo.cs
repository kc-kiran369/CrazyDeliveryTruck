using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorGizmo : MonoBehaviour
{
    public float Size = 2.0f;
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, new Vector3(Size, Size, Size));
    }
}