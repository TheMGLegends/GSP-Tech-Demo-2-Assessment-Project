using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GO follows specified object
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [Header("Camera Position:")]
    [SerializeField] private Transform cameraPosition;

    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
