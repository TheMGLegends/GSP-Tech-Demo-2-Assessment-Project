using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TypeWriterController : MonoBehaviour
{
    [SerializeField] private float typewriterEffectDelay;
    [SerializeField] private float endOfLineDelay;
    [SerializeField] private TMP_Text typewriterText;
    [SerializeField] private List<string> textPhrasesList = new List<string>();
    [SerializeField] private List<AudioClip> audioPhrasesList = new List<AudioClip>();

    private AudioSource audioSource;
    private bool isTalking = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
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
            audioSource.PlayOneShot(audioPhrasesList[i]);

            for (int j = 0; j < textPhrasesList[i].Length; j++)
            {
                typewriterText.text += textPhrasesList[i][j];
                yield return new WaitForSeconds(typewriterDelay);
                delayPerPhrase += typewriterDelay;
            }

            if (audioDuration > delayPerPhrase)
            {
                yield return new WaitForSeconds((audioDuration - delayPerPhrase) + endOfLineDelay);
            }
            delayPerPhrase = 0;
            typewriterText.text = null;
        }
        typewriterText.text = null;
        isTalking = false;
    }
}
