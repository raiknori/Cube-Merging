using System.Collections;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
{
    public void Run(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
