using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// Manages all the cameras in the game
/// </summary>
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
        // INFO: Disables old camera and enables new camera
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
        // INFO: Gets the player camera, which is the camera that all instances return to
        return playerCamera;
    }
}
