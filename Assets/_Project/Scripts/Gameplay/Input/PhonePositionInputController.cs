using UnityEngine;

public class PhonePositionInputController : MonoBehaviour, IPositionInput
{
    Vector2 holdPosition;
    public Vector3 HoldPosition => holdPosition;

    float cameraZDistance;

    void Start()
    {
        cameraZDistance = Camera.main.transform.position.z;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = touch.position;

            touchPos.z = -cameraZDistance;

            holdPosition = Camera.main.ScreenToWorldPoint(touchPos);
        }
    }
}