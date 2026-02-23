using System;

public interface IMergeService
{
    bool TryMerge(IMergeable first, IMergeable second);

    event Action<int> MergeCompleted;
}
