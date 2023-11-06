using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GO rotates based on Mouse X and Y inputs
/// </summary>
public class CameraRotation : MonoBehaviour
{
    [Header("Player Camera Settings:")]
    [SerializeField] private float xSensitivity;
    [SerializeField] private float ySensitivity;
    [Range(45, 90)] 
    [SerializeField] private float xRotationLimit;

    [Header("Player Transform:")]
    [SerializeField] private Transform playerOrientation;

    private float xRotation;
    private float yRotation;

    private float mouseX;
    private float mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        GetInputAxis();
        LookAround();
    }

    private void LookAround()
    {

        // INFO: Mosue input locked 
        if (CanvasManager.Instance.activeCanvas == CanvasManager.CanvasTypes.HUD)
        {
            xRotation -= mouseY * xSensitivity * Time.deltaTime;
            yRotation += mouseX * ySensitivity * Time.deltaTime;

            // INFO: Prevents rotation in x-axis (up/down from going beyond a certain limit)
            xRotation = Mathf.Clamp(xRotation, -xRotationLimit, xRotationLimit);

            Cursor.lockState = CursorLockMode.Locked;
            // INFO: Cameras X and Y are rotated but only players Y (left/right is rotated)
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            playerOrientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }

    private void GetInputAxis()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
    }
}
