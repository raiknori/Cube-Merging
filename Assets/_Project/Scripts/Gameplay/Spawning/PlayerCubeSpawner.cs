using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class PlayerCubeSpawner : MonoBehaviour, IImpactableObjectSpawner
{
    public event Action<IImpactableObject> Spawned;

    [SerializeField] GameObject cubePrefab;
    [SerializeField] Vector3 spawnPosition = new Vector3(0, -0.5f, -4);
    [SerializeField] float spawnCd;

    [Inject] private DiContainer _container;
    [Inject] private VisualizeService visualizeService;

    Action _releasedImpactableObject;
    public Action ReleasedImpactableObject => _releasedImpactableObject;

    private void Awake()
    {
        _releasedImpactableObject += StartSpawning;
    }

    private void OnDestroy()
    {
        _releasedImpactableObject -= StartSpawning;
    }

    public void Spawn()
    {
        GameObject spawnedGo = _container.InstantiatePrefab(cubePrefab, spawnPosition, Quaternion.identity, null);

        IImpactableObject obj = spawnedGo.GetComponent<IImpactableObject>();
        Spawned.Invoke(obj);

        visualizeService.VisualizeMerge(spawnedGo.GetComponent<IMergeable>());
    }

    void DefineValue(IMergeable mergeable)
    {
        if (UnityEngine.Random.Range(1, 25) <= 25)
        {
            mergeable.SetValue(4);
        }
        else
        {
            mergeable.SetValue(2);
        }
    }

    void StartSpawning()
    {
        StartCoroutine(CdSpawning());
    }

    IEnumerator CdSpawning()
    {
        yield return new WaitForSeconds(spawnCd);
        Spawn();
    }

    private void Start()
    {
        StartSpawning();
    }
}