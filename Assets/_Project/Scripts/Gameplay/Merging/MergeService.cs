using System;
using Zenject;

public class MergeService : IMergeService
{
    [Inject] private VisualizeService visualizeMergeService;
    [Inject] private AudioService audioService;

    public event Action<int> MergeCompleted;

    public bool TryMerge(IMergeable first, IMergeable second)
    {
        if (first == null || second == null)
            return false;

        if (first.Value != second.Value)
            return false;

        int newValue = first.Value * 2;

        first.SetValue(newValue);
        visualizeMergeService.VisualizeMerge(first);
        second.DestroySelf();

        MergeCompleted?.Invoke(newValue);
        audioService.PlaySound("merge");

        return true;
    }
}


