using UnityEngine;

public class PlayerCube : MonoBehaviour, IImpactableObject
{
    public Rigidbody Rigidbody => rb;

    public GameObject GameObject => gameObject;

    [SerializeField] Rigidbody rb;
}

