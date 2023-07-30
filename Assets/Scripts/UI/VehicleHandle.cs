using UnityEngine;
using UnityEngine.EventSystems;

public class VehicleHandle : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public float MaxSteerAngle = 35.0f;
    private RectTransform _rectTransform;
    private bool _canSteer = false;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData) => _canSteer = true;
    public void OnPointerUp(PointerEventData eventData)
    {
        _canSteer = false;
        ResetRotation();
    }
    public void Steer()
    {
        if (_canSteer)
        {
            //Get mouse Delta
            ApplyRotation(Input.mouseScrollDelta);

            //Send data to vehicle controller
        }
    }

    private void ApplyRotation(Vector2 mouseDelta)
    {
        //Apply rotation
        //Clamp rotation to max angle
    }
    private void ResetRotation() => _rectTransform.localEulerAngles = Vector3.zero;
}