using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Interactor interactor;
    [SerializeField] private Image tooltipIcon;

    private void Start()
    {
        tooltipIcon.enabled = false;
    }

    private void Update()
    {
        if (interactor.IsHovering() && !tooltipIcon.enabled)
        {
            tooltipIcon.enabled = true;
        }
        else if (!interactor.IsHovering() && tooltipIcon.enabled)
        {
            tooltipIcon.enabled = false;
        }
    }
}
