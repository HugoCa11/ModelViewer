using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{

    [SerializeField]
    private Camera cam;

    private float cameraOffsetZ;

    void Start()
    {
        cameraOffsetZ = cam.WorldToScreenPoint(transform.position).z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraOffsetZ);
            Vector3 newPos = cam.ScreenToWorldPoint(screenPosition);
            transform.position = newPos;
        }
    }
}
