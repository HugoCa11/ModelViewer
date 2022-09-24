using UnityEngine;
using TMPro;

public class PartSelector : MonoBehaviour
{

    // Main Camera
    [SerializeField]
    private Camera cam;

    // Text of the floating text box that will contain the part name
    [SerializeField]
    private TextMeshProUGUI partNameText;

    // Canvas containing the part name text
    [SerializeField]
    private GameObject textCanvas;

    // Model Part (Class)
    private MeshPart highlighted;

    // Model Part (Game Object)
    private GameObject selectedPiece;

    // Variable to store the position of the mouse in the previous frame
    private Vector3 prevPos = Vector3.zero;

    // Variable to stroe the difference between the previous position and
    // the position in the current frame
    private Vector3 deltaPos = Vector3.zero;

    void Update()
    {
        // Ray to detect when colliding with a model part
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // If the ray is hitting a part
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Save hit part
            MeshPart hitPart = hit.collider.GetComponentInParent<MeshPart>();

            // If ray hiting a part but nothing is selected
            if (hitPart != null) 
            {
                // If a part is highlited (Usually when it´s selected)
                if (highlighted != null)
                {
                    // If mouse is over a new part
                    if (highlighted != hitPart)
                    {
                        textCanvas.SetActive(false); // Deactivate name canvas
                    }
                }

                // Set highlited part as the one beeing hit
                highlighted = hitPart;

                // If left mouse button is presed over a piece
                if (Input.GetMouseButtonDown(0))
                {
                    // If previously another piece was selected
                    if(selectedPiece != null)
                    {
                        // Deselect the piece and remove highlight
                        selectedPiece.transform.GetComponent<MeshPart>().isPieceSelected = false;
                        selectedPiece.transform.GetComponent<MeshPart>().SetHighlighted(false);
                    }
                    // Set selestedPiece Game Object
                    selectedPiece = hit.transform.gameObject;

                    // Set text on the name canvas
                    partNameText.text = selectedPiece.name;

                    // Set piece as selected
                    highlighted.isPieceSelected = true;

                    // Get current mouse position
                    Vector3 newPoS = cam.ScreenToWorldPoint(Input.mousePosition);

                    // Set position of name canvas with a small ofsset on x
                    textCanvas.transform.position = new Vector3(newPoS.x + 1.25f, newPoS.y, textCanvas.transform.position.z);

                    // Activate name canvas
                    textCanvas.SetActive(true);
                }
            }
        }
        else // If the ray is not hitting a part
        {
            // If left mouse button is clicked
            if (Input.GetMouseButtonDown(0))
            {
                // Basically if a piece is selected showing its name and
                // the user clicks anywhere but the current selected piece
                // the name canvas is deactivated
                textCanvas.SetActive(false);

                if (selectedPiece != null)
                {
                    // Deselect the piece
                    selectedPiece = null;
                    highlighted = null;
                }

                // Check if the user is cliking over a UI
                if(cam.GetComponent<ZoomController>().IsPointerOverUIObject() == false)
                {
                    // If the user is clicking the empty space
                    MeshPart[] pieces = Object.FindObjectsOfType<MeshPart>();
                    foreach (MeshPart piece in pieces)
                    {
                        // Deselect all pieces and remove highlight.
                        // This function is useful when the user has selected pieces on the list.
                        piece.isPieceSelected = false;
                        piece.SetHighlighted(false);
                        piece.correspondingButton.GetComponent<PieceBtn>().highlight(false);
                    }
                }
            }
        }

        // If left mouse button is being holded and a piece is selected
        // the user should be able to move the pselected piece
        if (Input.GetMouseButton(0) && selectedPiece != null)
        {
            // Calculate the difference betwen the current and previos position of the mouse
            deltaPos = Input.mousePosition - prevPos;

            // Calculate new position.
            // As the mouse only moves in x and y axis the Z position is not updated based on the mouse position
            // X and Y are divided by 100 to get a slower movement.
            Vector3 newPos = new Vector3(deltaPos.x / 100, deltaPos.y / 100, selectedPiece.transform.position.z);
            Vector3 newCanvasPos = new Vector3(deltaPos.x / 100, deltaPos.y / 100, textCanvas.transform.position.z);

            // Update piece and name canvas position (move)
            selectedPiece.transform.position = new Vector3(selectedPiece.transform.position.x + newPos.x, selectedPiece.transform.position.y + newPos.y, selectedPiece.transform.position.z);
            textCanvas.transform.position = new Vector3(textCanvas.transform.position.x + newCanvasPos.x, textCanvas.transform.position.y + newCanvasPos.y, textCanvas.transform.position.z);
        }

        // If the user clicks the right or middle mouse button the name canvas should be deactivated
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            textCanvas.SetActive(false);
        }

        // Update prev position before next frame
        prevPos = Input.mousePosition;
    }
}
