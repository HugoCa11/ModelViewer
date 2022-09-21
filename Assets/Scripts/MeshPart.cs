using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshPart : MonoBehaviour
{

    private float cameraOffsetZ;
    void Start()
    {
        cameraOffsetZ = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    void Update()
    {
        //if (Input.GetMouseButton(1))
        //{
            //Debug.Log($"Name: {transform.name}");
            /*Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraOffsetZ);
            Vector3 newPos = Camera.main.ScreenToWorldPoint(screenPosition);
            transform.position = newPos;*/
        //}
    }
    public void SetHighlighted(bool value)
    {
        Material material = GetComponent<Renderer>().material;

        material.SetColor("_EmissionColor", value ? new Color(0.5f, 0.5f, 0.5f, 1) : Color.black);
        material.EnableKeyword("_EMISSION");
    }
}
