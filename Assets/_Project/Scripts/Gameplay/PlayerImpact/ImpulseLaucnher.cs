using UnityEngine;
using Zenject;

public class ImpulseLaucnher : MonoBehaviour
{
    [SerializeField] private float _launchForce = 1f;
    
    private Rigidbody rb;

    [Inject] IHoldInput input;
    [Inject] IImpactableObjectSpawner spawner;
    [Inject] AudioService audioService;

    private IImpactableObject _impactableObject;
    private void Awake()
    {
        input.InputReleased += Launch;
        spawner.Spawned += SetTarget;
    }

    void SetTarget(IImpactableObject impactableObject)
    {
        _impactableObject = impactableObject;
    }

    void Launch()
    {
        if (_impactableObject == null) return;

        _impactableObject.Rigidbody.AddForce(transform.forward * _launchForce * Time.fixedDeltaTime * 100f, ForceMode.Impulse );
        _impactableObject = null;
        spawner.ReleasedImpactableObject?.Invoke();

        audioService.PlaySound("throw");
    }

}   
