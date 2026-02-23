using UnityEngine;
using System.Collections.Generic;
using Zenject;

public class AudioService:MonoBehaviour
{
    [SerializeField] AudioSource soundAudioSource;
    [SerializeField] AudioSource musicAudioSource;
    Dictionary<string, SoundData> cache = new Dictionary<string, SoundData>();

    [Inject] DataLoader loader;

    private void Awake()
    {
        LoadAudio();
    }

    void LoadAudio()
    {
        var data = loader.LoadAll<SoundData>("Audio");

        foreach (var item in data)
        {
            cache.Add(item.key, item);
        }

    }


    public void PlaySound(string key)
    {
        if(!cache.ContainsKey(key))
        {
            Debug.LogWarning($"Dont find any `{key}` sound data in audio cache!");
            return;
        }


        var soundData = cache[key];

        if(soundData.randomPitchShift>0)
        {
            soundAudioSource.pitch = UnityEngine.Random.Range
                (1-soundData.randomPitchShift,
                1+soundData.randomPitchShift);
        }

        var clip = soundData.clip;

        if (clip != null)
            soundAudioSource.PlayOneShot(clip);

        soundAudioSource.pitch = 1;
    }
    
    public void PlayMusic(string key, bool looped = false)
    {
        if (musicAudioSource.isPlaying)
            musicAudioSource.Stop();

        if (!cache.ContainsKey(key))
            return;

        var soundData = cache[key];

        musicAudioSource.loop = looped;
        musicAudioSource.clip = soundData.clip;

        musicAudioSource.Play();
    }
}
