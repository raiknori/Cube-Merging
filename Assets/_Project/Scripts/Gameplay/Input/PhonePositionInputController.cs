using UnityEngine;

public class PhonePositionInputController : MonoBehaviour, IPositionInput
{
    Vector2 holdPosition;
    public Vector3 HoldPosition => holdPosition;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = touch.position;

            touchPos.z = Camera.main.WorldToScreenPoint(transform.position).z;

            holdPosition = Camera.main.ScreenToWorldPoint(touchPos);
        }
    }
}