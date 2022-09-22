using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshPart : MonoBehaviour
{
    public bool pieceSelected = false;
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        SetHighlighted(true);
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        if (!pieceSelected)
        {
            SetHighlighted(false);
        }
    }

    public void SetHighlighted(bool value)
    {
        Material material = GetComponent<Renderer>().material;

        material.SetColor("_EmissionColor", value ? new Color(0.5f, 0.5f, 0.5f, 1) : Color.black);
        material.EnableKeyword("_EMISSION");
    }

}
