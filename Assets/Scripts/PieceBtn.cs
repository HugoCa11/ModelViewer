using UnityEngine;
using TMPro;

public class PieceBtn : MonoBehaviour
{
    // Color for text when button is selected
    private Color selectedColor = Color.yellow;
    private Color deselectedColor = Color.white;

    // Reference to the piece controlled by the button
    public MeshPart piece;

    // Variable to set the highlited state
    private bool isHighlited = false;

    // Function called when the button is clicked
    public void highlight()
    {
        isHighlited = !isHighlited;

        // Highlight and select the piece controlled by the button
        piece.isPieceSelected = isHighlited;
        piece.SetHighlighted(isHighlited);

        if (isHighlited)
        {
            transform.GetComponentInChildren<TextMeshProUGUI>().color = selectedColor;
        }
        else
        {
            transform.GetComponentInChildren<TextMeshProUGUI>().color = deselectedColor;
        }
    }

    // Function called from other scripts
    public void highlight(bool value)
    {
        isHighlited = value;

        if (isHighlited)
        {
            transform.GetComponentInChildren<TextMeshProUGUI>().color = selectedColor;
        }
        else
        {
            transform.GetComponentInChildren<TextMeshProUGUI>().color = deselectedColor;
        }
    }
}
