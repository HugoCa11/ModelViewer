using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if(IsPointerOverUIObject() == false)
        {
            cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        }
    }

    // Check if mouse over UI Object
    public bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);

        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();

        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
}
