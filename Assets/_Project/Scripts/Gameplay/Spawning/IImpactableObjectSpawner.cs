using System;

public interface IImpactableObjectSpawner
{
    public event Action<IImpactableObject> Spawned;
    public Action ReleasedImpactableObject { get; }
}
