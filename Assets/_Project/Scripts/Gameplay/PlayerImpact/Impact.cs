using System.Collections;
using UnityEngine;
using Zenject;

public class Impact : IInitializable
{
    [Inject] IMergeService mergeService;
    [Inject] IObjectLauncher launcher;
    [Inject] ICoroutineRunner coroutineRunner;
    [Inject] AudioService audioService;
    public void Initialize()
    {
        mergeService.MergeCompleted += MergeImpact;
        launcher.ObjectReleased += ThrowImpact;
    }

    void MergeImpact(int value)
    {
        coroutineRunner.Run(MergeSoundDelay());
    }

    IEnumerator MergeSoundDelay()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f,0.2f));
        audioService.PlaySound("merge");
    }

    void ThrowImpact()
    {
        audioService.PlaySound("throw");
    }
}
