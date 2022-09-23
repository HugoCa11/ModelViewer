using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceBtn : MonoBehaviour
{

    public MeshPart piece;
    private bool isHighlited = false;

    public void highlight()
    {
        isHighlited = !isHighlited;
        piece.SetHighlighted(isHighlited);
    }
}
