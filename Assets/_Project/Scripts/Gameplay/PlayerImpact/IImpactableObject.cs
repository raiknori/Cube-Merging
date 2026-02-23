using UnityEngine;

public interface IImpactableObject
{
    public Rigidbody Rigidbody { get; }
    public GameObject GameObject { get; }
}
