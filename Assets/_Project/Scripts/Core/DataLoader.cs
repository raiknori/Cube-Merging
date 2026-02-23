using UnityEngine;

public class DataLoader 
{
    public T Load<T>(string path) where T : UnityEngine.Object
    {
        return Resources.Load<T>($"{path}");
    }

    public T[] LoadAll<T>(string path) where T : UnityEngine.Object
    {
        return Resources.LoadAll<T>($"{path}");
    }

}


