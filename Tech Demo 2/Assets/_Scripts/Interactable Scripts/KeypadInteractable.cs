using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// Keypad interactable object handles logic for keypad:
/// 1. Initializing random 4 digit code at runtime
/// 2. Setting the appropriate canvas and camera for a proper keypad interaction
/// 3. Playing sounds when keys are pressed
/// 4. Checking keys that were pressed to see what appropriate function should be run:
///     a). If 0-9 (Inclusive) add number to currentAnswer
///     b). If 10-12 (Inclusive) special keys pressed (Enter, Clear, Delete), run relevant function
/// 5. Comparing codes when enter key is pressed:
///     a). If correct, display green, sound plays and relating action occurs (Door open animation with sound effect)
///     b). If incorrect, display red, sound plays and input gets cleared after specified delay
/// </summary>
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
        // INFO: Random 4 digit code generated
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
        // INFO: Gets the starting color of the digit display screen
        startingColor = meshRenderer.material.GetColor("_EmissionColor");

        Debug.Log(actualAnswer);       
    }

    public void Interact()
    {
        Debug.Log("Interacting with keypad!");
        boxCollider.enabled = false;
        isBoxActive = false;
        // INFO: Shows relevant canvas relating to interaction
        CanvasManager.Instance.ShowCanvas(CanvasManager.CanvasTypes.KeypadPrompts);
        // INFO: Switches the relevant camera for interaction
        CameraManager.Instance.SetCurrentCamera(keypadCamera);
    }

    private void Update()
    {
        // INFO: Re-enables keypad box collider so that when user looks at the keypad again outline works as it should
        if (keypadCamera.GetComponent<Camera>().enabled == false && !isBoxActive)
        {
            boxCollider.enabled = true;
            isBoxActive = true;
            Debug.Log("Camera change");
        }
    }

    public void AddInput(int input)
    {
        if (!isAnswerCorrect)
        {
            // INFO: Given that the user hasn't yet input 4 digits and the input is less than 10 (0 - 9)
            // we know that the input is its corresponding int value so we add it to the current answer
            if (currentAnswer.Length < actualAnswer.Length && input < 10)
            {
                currentAnswer += input;
                keypadText.text = currentAnswer;
            }

            // INFO: All keys except enter have a key pressed sound (Enter has different sounds [Correct and Incorrect])
            if (input != (int)ButtonIDs.Enter)
            {
                SFXManager.Instance.PlaySoundEffect(SFXManager.SoundEffects.CodePress);
            }

            // INFO: Given that number is 10+ it signifies special key and needs further checking
            CheckNumber(input);
        }
    }


    private void RemoveNumber()
    {
        // INFO: Only get rid of the last character if there are characters to get rid of
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
