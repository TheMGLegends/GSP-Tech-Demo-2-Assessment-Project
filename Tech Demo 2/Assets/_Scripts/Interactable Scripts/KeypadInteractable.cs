using System.Collections;
using TMPro;
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
    [SerializeField] private DocumentInteractable codeDocument;
    [SerializeField] private Animator doorAnimator;

    private BoxCollider boxCollider;
    private bool isBoxActive = true;

    private bool isAnswerCorrect = false;
    private bool isInputLocked = false;
    private string currentAnswer = "";
    private Color startingColor;

    private void Awake()
    {
        for (int i = 0; i < codeSize; i++)
        {
            int temp = Random.Range(0, 10);
            actualAnswer += temp;
        }

        codeDocument.SetDocumentText(actualAnswer);
    }

    protected override void Start()
    {
        base.Start();
        boxCollider = GetComponent<BoxCollider>();
        keypadText.text = null;
        startingColor = meshRenderer.material.GetColor("_EmissionColor");

        Debug.Log(actualAnswer);       
    }

    public void Interact()
    {
        Debug.Log("Interacting with keypad!");
        boxCollider.enabled = false;
        isBoxActive = false;
        CanvasManager.Instance.ShowCanvas(CanvasManager.CanvasTypes.KeypadPrompts);
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

            StartCoroutine(DoorOpenCoroutine(SFXManager.Instance.GetSoundLength(SFXManager.SoundEffects.CodeCorrect) + 0.5f));
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

        Clear();
        meshRenderer.material.SetColor("_EmissionColor", startingColor);
        isInputLocked = false;
    }

    private IEnumerator DoorOpenCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        doorAnimator.SetBool("isOpen", true);
        SFXManager.Instance.PlaySoundEffect(SFXManager.SoundEffects.DoorOpen);
    }

    public bool IsInputLocked()
    {
        return isInputLocked;
    }
}
