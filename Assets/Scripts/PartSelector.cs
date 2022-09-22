using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PartSelector : MonoBehaviour
{

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private TextMeshProUGUI partNameText;

    [SerializeField]
    private GameObject textCanvas;

    private MeshPart highlighted;
    private GameObject selectedPiece;
    private Vector3 prevPos = Vector3.zero;
    private Vector3 deltaPos = Vector3.zero;

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // If the Raycast is hiting something

            MeshPart hitPart = hit.collider.GetComponentInParent<MeshPart>();

            if (hitPart != null && selectedPiece == null)
            {
                
                if (highlighted != null)
                {
                    if (highlighted != hitPart)
                    {
                        highlighted.pieceSelected = false;
                        highlighted.SetHighlighted(false);
                        textCanvas.SetActive(false);
                    }
                }

                highlighted = hitPart;

                if (Input.GetMouseButtonDown(0))
                {
                    selectedPiece = hit.transform.gameObject;
                    partNameText.text = selectedPiece.name;
                    highlighted.pieceSelected = true;
                    Vector3 newPoS = cam.ScreenToWorldPoint(Input.mousePosition);
                    textCanvas.transform.position = new Vector3(newPoS.x + 1.25f, newPoS.y, textCanvas.transform.position.z);
                    textCanvas.SetActive(true);
                }
            }
        }
        else
        {
            // If the Raycast is not hiting anything

            if (Input.GetMouseButtonDown(0))
            {
                textCanvas.SetActive(false);
                //Debug.Log($"Null");
            }
        }

        if (Input.GetMouseButton(0) && selectedPiece != null)
        {
            deltaPos = Input.mousePosition - prevPos;
            Vector3 newPos = new Vector3(deltaPos.x / 100, deltaPos.y / 100, selectedPiece.transform.position.z);
            Vector3 newCanvasPos = new Vector3(deltaPos.x / 100, deltaPos.y / 100, textCanvas.transform.position.z);
            selectedPiece.transform.position = new Vector3(selectedPiece.transform.position.x + newPos.x, selectedPiece.transform.position.y + newPos.y, selectedPiece.transform.position.z);
            textCanvas.transform.position = new Vector3(textCanvas.transform.position.x + newCanvasPos.x, textCanvas.transform.position.y + newCanvasPos.y, textCanvas.transform.position.z);
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedPiece = null;
        }

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            textCanvas.SetActive(false);
        }
        
        prevPos = Input.mousePosition;
    }
}
