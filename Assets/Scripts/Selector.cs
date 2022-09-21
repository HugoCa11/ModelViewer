using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{

    [SerializeField]
    private Camera cam;

    private MeshPart highlighted;
    private float cameraOffsetZ;
    private GameObject selectedPiece;

    void Update()
    {
        if (highlighted != null)
        {
            highlighted.SetHighlighted(false);
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            MeshPart hitPart = hit.collider.GetComponentInParent<MeshPart>();

            if (hitPart != null)
            {
                hitPart.SetHighlighted(true);

                highlighted = hitPart;

                if (Input.GetMouseButtonDown(1))
                {
                    selectedPiece = hit.transform.gameObject;
                    cameraOffsetZ = cam.WorldToScreenPoint(selectedPiece.transform.position).z;
                    Debug.Log(selectedPiece.transform.name);
                }
                if (Input.GetMouseButtonUp(1))
                {
                    selectedPiece = null;
                    cameraOffsetZ = 0.0f;
                }
            }
        }

        if (Input.GetMouseButton(1) && selectedPiece != null)
        {
            //Debug.Log(selectedPiece.transform.name);
            Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraOffsetZ);
            Vector3 newPos = Camera.main.ScreenToWorldPoint(screenPosition);
            selectedPiece.transform.position = newPos;
        }
    }
}
