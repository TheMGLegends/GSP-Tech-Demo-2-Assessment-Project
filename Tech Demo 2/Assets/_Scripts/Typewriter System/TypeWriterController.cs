using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Handles the typewriter effect 
/// </summary>
public class TypeWriterController : MonoBehaviour
{
    [SerializeField] private float typewriterEffectDelay;
    [SerializeField] private float endOfLineDelay;
    [SerializeField] private TMP_Text typewriterText;
    [SerializeField] private List<string> textPhrasesList = new();
    [SerializeField] private List<AudioClip> audioPhrasesList = new();
    [Range(0, 1)]
    [SerializeField] private float soundVolume = 1f;

    private AudioSource audioSource;
    private bool isTalking = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // INFO: isTalking prevents audio and text from displaying twice if player steps in and out of trigger
        if (other.CompareTag("Player") && !isTalking)
        {
            if (textPhrasesList.Count == audioPhrasesList.Count) 
            {
                isTalking = true;
                StartCoroutine(TypewriterCoroutine(typewriterEffectDelay));
            }
            else
            {
                Debug.Log("Phrases and Audio Clips do not match!");
            }
        }
    }

    private IEnumerator TypewriterCoroutine(float typewriterDelay)
    {
        for (int i = 0; i < textPhrasesList.Count; i++)
        {
            float delayPerPhrase = 0;
            float audioDuration = audioPhrasesList[i].length;
            audioSource.PlayOneShot(audioPhrasesList[i], soundVolume);

            for (int j = 0; j < textPhrasesList[i].Length; j++)
            {
                // INFO: Displays text a character at a time
                typewriterText.text += textPhrasesList[i][j];
                yield return new WaitForSeconds(typewriterDelay);
                delayPerPhrase += typewriterDelay;
            }

            // INFO: Given that the audio clip is longer than the length that is has taken for the entire phrase to be displayed on screen
            // we wait the remainder of the time left + a constant end of line delay before we move onto the next phrase and audio clip
            if (audioDuration > delayPerPhrase)
            {
                yield return new WaitForSeconds((audioDuration - delayPerPhrase) + endOfLineDelay);
            }
            typewriterText.text = null;
        }
        typewriterText.text = null;
        isTalking = false;
    }
}
