using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{
    void LateUpdate()
    {
        Transform currentTransform = transform;
        Transform vehicleTransform = Vehicle.GetInstance().GetTransform;

        Vector3 targetTransform = new Vector3(vehicleTransform.position.x, currentTransform.position.y, vehicleTransform.position.z);
        Quaternion targetRotation = Quaternion.Euler(90, vehicleTransform.eulerAngles.y, 0);

        transform.position = targetTransform;
        transform.rotation = targetRotation;
    }
}
