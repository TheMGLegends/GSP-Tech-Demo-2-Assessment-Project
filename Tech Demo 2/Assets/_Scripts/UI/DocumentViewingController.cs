using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.X))
        {
            CanvasManager.instance.ShowCanvas(CanvasManager.CanvasTypes.HUD);

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
            inspectionObject.SetActive(false);
            isInspecting = false;
        }
    }

    public void SetDocumentContentsText(string text)
    {
        documentContents.text = text;
    }
}