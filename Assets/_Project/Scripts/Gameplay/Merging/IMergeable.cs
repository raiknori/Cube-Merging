using TMPro;
using UnityEngine;

public interface IMergeable
{
    int Value { get; }
    void SetValue(int newValue);
    void DestroySelf();

    TextMeshProUGUI[] EdgesText { get; }
    Renderer Renderer { get; }
}
