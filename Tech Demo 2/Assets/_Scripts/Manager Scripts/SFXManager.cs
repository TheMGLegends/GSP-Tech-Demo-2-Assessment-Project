using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public enum SoundEffects
    {
        ItemUsed
    }
    
    public static SFXManager Instance;

    [SerializeField] private List<SoundEffects> soundEffectsList = new();
    [SerializeField] private List<AudioClip> audioClipsList = new();
    [SerializeField] private Dictionary<SoundEffects, AudioClip> soundEffectsDictionary = new();
    [SerializeField] private GameObject soundEffectsPlayerPrefab;
    [Range(0, 1)]
    [SerializeField] private float soundVolume = 1f;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < soundEffectsList.Count; i++)
        {
            soundEffectsDictionary.Add(soundEffectsList[i], audioClipsList[i]);
        }
    }

    public void PlaySoundEffect(SoundEffects soundEffect)
    {
        if (soundEffectsDictionary.ContainsKey(soundEffect))
        {
            GameObject GO = Instantiate(soundEffectsPlayerPrefab);
            GO.GetComponent<AudioSource>().PlayOneShot(soundEffectsDictionary[soundEffect], soundVolume);
            Destroy(GO, soundEffectsDictionary[soundEffect].length);
        }
        else
        {
            Debug.Log("Sound not found!");
        }
    }
}