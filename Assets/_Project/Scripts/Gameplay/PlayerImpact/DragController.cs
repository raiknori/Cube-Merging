    using UnityEngine;
using Zenject;

public class DragController : MonoBehaviour
{
    [Inject] IHoldInput holdInput;
    [Inject] IPositionInput positionInput;
    [Inject] IImpactableObjectSpawner spawner;


    private bool holded = false;

    private IImpactableObject _impactableObject;

    private void Awake()
    {
        holdInput.InputHolded += DownInput;
        holdInput.InputReleased += ReleaseInput;
        spawner.Spawned += SetTarget;
    }

    private void FixedUpdate()
    {
        if (holded)
        {
            Drag();
        }
    }

    void SetTarget(IImpactableObject impactableObject)
    {
        _impactableObject = impactableObject;
    }
    void DownInput()
    {
        holded = true;
    }
    void ReleaseInput()
    {
        holded = false;
        _impactableObject = null;
    }

    void Drag()
    {
        if(_impactableObject==null)
            return;

        float targetX = positionInput.HoldPosition.x;

        targetX = Mathf.Clamp(targetX, -4, 4);

        Vector3 newPos = _impactableObject.Rigidbody.position;
        newPos.x = targetX;

        _impactableObject.Rigidbody.MovePosition(newPos);
    }
}
