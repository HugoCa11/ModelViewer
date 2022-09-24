using UnityEngine;

public class MeshPart : MonoBehaviour
{
    // Material for highlighted status
    [SerializeField]
    private Material highlitMaterial;

    [SerializeField]
    private Material xRayMaterial;

    // Material in normal status
    private Material normalMaterial;

    public bool isPieceSelected = false;
    public bool xRayActive = false;

    public GameObject correspondingButton;

    void Start()
    {
        // Get normal estatus material
        normalMaterial = GetComponent<Renderer>().material;
    }

    void OnMouseOver()
    {
        // Highlight piece when mouse over
        SetHighlighted(true);
    }

    void OnMouseExit()
    {
        // Stop highlighting the piece when mouse exits and the piece is not selected
        if (!isPieceSelected)
        {
            SetHighlighted(false);
        }
    }

    // Method to highlight the piece
    public void SetHighlighted(bool value)
    {
        // Highlight the Piece
        if (value)
        {
            GetComponent<Renderer>().material = highlitMaterial;
            correspondingButton.GetComponent<PieceBtn>().highlight(value);
        }
        else
        {
            if (!xRayActive)
            {
                GetComponent<Renderer>().material = normalMaterial;
            }
            else
            {
                GetComponent<Renderer>().material = xRayMaterial;
            }
            
            correspondingButton.GetComponent<PieceBtn>().highlight(value);
        }
    }

}
