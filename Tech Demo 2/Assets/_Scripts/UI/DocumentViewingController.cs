using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Controls the document viewer 
/// </summary>
public class DocumentViewingController : MonoBehaviour
{
    [SerializeField] private GameObject inspectionObject;
    [SerializeField] private TMP_Text documentContents;

    private TMP_Text inspectionText;
    private bool isInspecting = false;

    private void Start()
    {
        inspectionObject.SetActive(false);
        inspectionText = inspectionObject.GetComponentInChildren<TMP_Text>(true);
    }
    private void Update()
    {
        InteractWithDocument();
    }

    private void InteractWithDocument()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            CanvasManager.Instance.ShowCanvas(CanvasManager.CanvasTypes.HUD);

            // INFO: Disables inspecting component if exiting when inspecting
            if (isInspecting)
            {
                inspectionObject.SetActive(false);
                isInspecting = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.I) && !isInspecting)
        {
            isInspecting = true;
            inspectionObject.SetActive(true);
            inspectionText.text = documentContents.text;
        }
        else if (Input.GetKeyDown(KeyCode.I) && isInspecting)
        {
            isInspecting = false;
            inspectionObject.SetActive(false);
        }
    }

    public void SetDocumentContentsText(string text)
    {
        documentContents.text = text;
    }
}
