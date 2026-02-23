
using TMPro;
using UnityEngine;
using Zenject;

public class MergeCube : MonoBehaviour, IMergeable
{
    [SerializeField] TextMeshProUGUI[] edgesText = new TextMeshProUGUI[6];
    [SerializeField] Renderer renderer;

    [SerializeField] private PlayerCube _playerCube;
    

    [Inject] private IMergeService mergeService;

    public PlayerCube PlayerCube => _playerCube;

    int value = 2;

    public int Value => value;

    public TextMeshProUGUI[] EdgesText => edgesText;

    public Renderer Renderer => renderer;

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void SetValue(int newValue)
    {
        value = newValue;
        Debug.Log($"{gameObject.name} new value: {value}");
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<MergeCube>(out var collisionCube))
        {
            if (collisionCube.PlayerCube.Rigidbody.linearVelocity.magnitude > _playerCube.Rigidbody.linearVelocity.magnitude)
            {
                Debug.Log($"{collisionCube.name} crashed into {gameObject.name}");
                mergeService.TryMerge(this, collisionCube);
            }
        }

    }

}
