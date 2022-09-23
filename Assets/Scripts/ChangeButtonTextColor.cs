using UnityEngine;
using TMPro;

public class ChangeButtonTextColor : MonoBehaviour
{
    // Color for text when button is selected
    private Color selectedColor = Color.yellow;
    private Color deselectedColor = Color.white;

    // Variable to change the selected state
    private bool isSelected = false;

    public void changeTextColor()
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
