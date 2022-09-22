using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSelector : MonoBehaviour
{

    [SerializeField]
    private Camera cam;

    private MeshPart highlighted;
    private bool clicked = false;
    private GameObject selectedPiece;
    private Vector3 prevPos = Vector3.zero;
    private Vector3 deltaPos = Vector3.zero;

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            MeshPart hitPart = hit.collider.GetComponentInParent<MeshPart>();

            if (hitPart != null && selectedPiece == null)
            {
                
                if(highlighted != null)
                {
                    if (highlighted != hitPart)
                    {
                        highlighted.pieceSelected = false;
                        highlighted.SetHighlighted(false);
                    }
                }

                highlighted = hitPart;

                if (Input.GetMouseButtonDown(0))
                {
                    selectedPiece = hit.transform.gameObject;
                    highlighted.pieceSelected = true;
                }
            }
        }

        if (Input.GetMouseButton(0) && selectedPiece != null)
        {
            deltaPos = Input.mousePosition - prevPos;
            Vector3 newPos = new Vector3(deltaPos.x / 100, deltaPos.y / 100, selectedPiece.transform.position.z);
            selectedPiece.transform.position += newPos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedPiece = null;
        }

        prevPos = Input.mousePosition;
    }
}
