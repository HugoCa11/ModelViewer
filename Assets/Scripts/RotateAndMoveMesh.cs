using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndMoveMesh : MonoBehaviour
{

    [SerializeField]
    private Camera cam;

    private Vector3 prevPos = Vector3.zero;
    private Vector3 deltaPos = Vector3.zero;

    private float cameraOffsetZ;

    void Start()
    {
        cameraOffsetZ = cam.WorldToScreenPoint(transform.position).z;
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            deltaPos = Input.mousePosition - prevPos;
            if(Vector3.Dot(transform.up, Vector3.up) >= 0)
            {
                transform.Rotate(transform.up, -Vector3.Dot(deltaPos, cam.transform.right), Space.World);
            }
            else
            {
                transform.Rotate(transform.up, Vector3.Dot(deltaPos, cam.transform.right), Space.World);
            }

            transform.Rotate(cam.transform.right, Vector3.Dot(deltaPos, cam.transform.up), Space.World);
        }

        prevPos = Input.mousePosition;

        if (Input.GetMouseButton(2))
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraOffsetZ);
            Vector3 newPos = cam.ScreenToWorldPoint(screenPosition);
            transform.position = newPos;
        }
        else if (Input.GetMouseButtonUp(2))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
