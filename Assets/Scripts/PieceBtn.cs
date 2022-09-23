using UnityEngine;

public class PieceBtn : MonoBehaviour
{
    // Reference to the piece controlled by the button
    public MeshPart piece;

    // Variable to set the highlited state
    private bool isHighlited = false;

    public void highlight()
    {
        isHighlited = !isHighlited;
        // Highlight the piece controlled by the button
        piece.isBtnSelection = isHighlited;
        piece.SetHighlighted(isHighlited);
    }
}
