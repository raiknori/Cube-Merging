using UnityEngine;

[CreateAssetMenu(fileName = "SoundData", menuName ="Sounds")]
public class SoundData : ScriptableObject
{
    public AudioClip clip;
    public string key;
    [Range(0,10)] public float randomPitchShift;
}