using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class KeypadInteractable : InteractableBaseClass, IInteractable
{
    enum ButtonIDs
    {
        Enter = 10,
        Clear,
        Delete,
    }

    [SerializeField] private GameObject keypadCamera;
    [SerializeField] private TMP_Text keypadText;
    [SerializeField] private string actualAnswer;
    [SerializeField] private int codeSize;
    [SerializeField] private float incorrectCodeDelay;

    private BoxCollider boxCollider;
    private bool isBoxActive = true;

    private bool isAnswerCorrect = false;
    private bool isInputLocked = false;
    private string currentAnswer = "";
    private Color startingColor;

    protected override void Start()
    {
        base.Start();
        boxCollider = GetComponent<BoxCollider>();

        for (int i = 0; i < codeSize; i++)
        {
            int temp = Random.Range(0, 10);
            actualAnswer += temp;
        }

        keypadText.text = null;
        startingColor = meshRenderer.material.GetColor("_EmissionColor");

        Debug.Log(actualAnswer);
    }

    public void Interact()
    {
        Debug.Log("Interacting with keypad!");
        CanvasManager.Instance.ShowCanvas(CanvasManager.CanvasTypes.KeypadView);
        boxCollider.enabled = false;
        isBoxActive = false;
        CameraManager.Instance.SetCurrentCamera(keypadCamera);
    }

    private void Update()
    {
        if (keypadCamera.GetComponent<Camera>().enabled == false && !isBoxActive)
        {
            boxCollider.enabled = true;
            isBoxActive = true;
            Debug.Log("Camera change yes");
        }
    }

    public void AddInput(int input)
    {
        if (!isAnswerCorrect)
        {
            if (currentAnswer.Length < actualAnswer.Length && input < 10)
            {
                currentAnswer += input;
                keypadText.text = currentAnswer;
            }

            if (input != (int)ButtonIDs.Enter)
            {
                SFXManager.Instance.PlaySoundEffect(SFXManager.SoundEffects.CodePress);
            }

            CheckNumber(input);
        }
    }


    private void RemoveNumber()
    {
        if (currentAnswer.Length > 0)
        {
            currentAnswer = currentAnswer[..^1];
            keypadText.text = currentAnswer;
        }
    }

    private void CheckNumber(int input)
    {
        switch (input)
        {
            case (int)ButtonIDs.Enter:
                Enter();
                break;
            case (int)ButtonIDs.Clear:
                Clear();
                break;
            case (int)ButtonIDs.Delete:
                Delete();
                break;
        }
    }

    private void CompareCodes()
    {
        if (actualAnswer == currentAnswer && !isAnswerCorrect)
        {
            Debug.Log("Correct code entered!");
            SFXManager.Instance.PlaySoundEffect(SFXManager.SoundEffects.CodeCorrect);
            meshRenderer.material.SetColor("_EmissionColor", Color.green);
            isAnswerCorrect = true;
        }
        else if (actualAnswer != currentAnswer)
        {
            Debug.Log("Wrong code entered!");
            SFXManager.Instance.PlaySoundEffect(SFXManager.SoundEffects.CodeWrong);
            meshRenderer.material.SetColor("_EmissionColor", Color.red);

            StartCoroutine(IncorrectCoroutine(incorrectCodeDelay));
        }
        
        isInputLocked = true;
    }

    private void Enter()
    {
        CompareCodes();
    }

    private void Clear()
    {
        currentAnswer = "";
        keypadText.text = currentAnswer;
    }

    private void Delete()
    {
        RemoveNumber();
    }

    private IEnumerator IncorrectCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        meshRenderer.material.SetColor("_EmissionColor", startingColor);
        isInputLocked = false;
    }

    public bool IsInputLocked()
    {
        return isInputLocked;
    }
}
