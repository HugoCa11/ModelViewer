using UnityEngine;
using TMPro;

public class ChangeButtonStatus : MonoBehaviour
{
    // Color for text when button is selected
    private Color selectedColor = Color.yellow;
    private Color deselectedColor = Color.white;

    // Variable to set the highlited state
    private bool isSelected = false;
    
    public void ChangeState()
    {
        isSelected = !isSelected;

        if (isSelected)
        {
            transform.GetComponentInChildren<TextMeshProUGUI>().color = selectedColor;
        }
        else
        {
            transform.GetComponentInChildren<TextMeshProUGUI>().color = deselectedColor;
        }
    }
}
