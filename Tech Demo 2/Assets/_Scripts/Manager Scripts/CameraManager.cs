using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private GameObject playerCamera;

    private GameObject currentCamera;

    private void Start()
    {
        currentCamera = playerCamera;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetCurrentCamera(GameObject newCamera)
    {
        if (currentCamera != null)
        {
            currentCamera.GetComponent<Camera>().enabled = false;
            currentCamera.GetComponent<AudioListener>().enabled = false;

            currentCamera = newCamera;

            currentCamera.GetComponent<Camera>().enabled = true;
            currentCamera.GetComponent<AudioListener>().enabled = true;
        }
    }

    public GameObject GetPlayerCamera()
    {
        return playerCamera;
    }
}
