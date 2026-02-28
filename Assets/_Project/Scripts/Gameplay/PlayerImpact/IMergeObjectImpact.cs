using Zenject;

public class Impact : IInitializable
{
    [Inject] IMergeService mergeService;
    [Inject] IObjectLauncher launcher;
    [Inject] AudioService audioService;
    public void Initialize()
    {
        mergeService.MergeCompleted += MergeImpact;
        launcher.ObjectReleased += ThrowImpact;
    }

    void MergeImpact(int value)
    {
        audioService.PlaySound("merge");
    }

    void ThrowImpact()
    {
        audioService.PlaySound("throw");
    }
}