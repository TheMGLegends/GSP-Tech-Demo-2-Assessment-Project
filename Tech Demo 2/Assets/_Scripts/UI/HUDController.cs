using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private PlayerInteractor interactor;
    [SerializeField] private GameObject tooltipObject;
    [SerializeField] private GameObject typewriterObject;

    private void Start()
    {
        tooltipObject.SetActive(false);
    }

    private void Update()
    {
        if (interactor.IsHovering() && !tooltipObject.activeSelf)
        {
            tooltipObject.SetActive(true);
        }
        else if (!interactor.IsHovering() && tooltipObject.activeSelf)
        {
            tooltipObject.SetActive(false);
        }
    }
}
