using UnityEngine;

public class PositionInputController : MonoBehaviour, IPositionInput
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
        var mousePos = Input.mousePosition;

        mousePos.z = -cameraZDistance;

        holdPosition = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
