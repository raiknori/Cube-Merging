using UnityEngine;

public class PositionInputController : MonoBehaviour, IPositionInput
{
    Vector2 holdPosition;
    public Vector3 HoldPosition => holdPosition;


    private void Update()
    {
        var mousePos = Input.mousePosition;

        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;

        holdPosition = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
