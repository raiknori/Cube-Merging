using System.Collections;

public interface ICoroutineRunner
{
    void Run(IEnumerator coroutine);
}