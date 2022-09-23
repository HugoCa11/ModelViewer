using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    // Zoom Speed
    [SerializeField]
    private float zoomSpeed = 1;
    
    // Main Camera
    [SerializeField]
    private Camera cam;

    void Update()
    {
        // As the main camera is an ortographic camera the ortographic size can be changed to zoom in or out
        cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
    }
}
