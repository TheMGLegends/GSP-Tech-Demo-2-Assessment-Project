using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public enum SoundEffects
    {
        ItemUsed
    }

    // INFO: The order of sound effects and audio clips should be exactly the same, otherwise the incorrect sound will be played
    [SerializeField] private List<SoundEffects> soundEffectsList = new();
    [SerializeField] private List<AudioClip> audioClipsList = new();
    [SerializeField] private Dictionary<SoundEffects, AudioClip> soundEffectsDictionary = new();

    [SerializeField] private GameObject soundEffectsPlayerPrefab;

    private float soundVolume = 1f;

    public static SFXManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
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

    public void SoundEffectVolume(float volume)
    {
        // INFO: Changed via slider for sound effect volume bar inside of settings menu
        soundVolume = volume;
    }
}
