using TMPro;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class ControllerWholeModel : MonoBehaviour
{
    [Header("Material for Mesh Parts")]    
    [SerializeField]
    Material xRayMaterial; // Material for X-Ray mode

    [SerializeField]
    Material normalMaterial; // MAterial for regular mode
    [Space(5)]

    [Header("Tree List Components")]
    [SerializeField]
    List<GameObject> listBodies; // List of "Body" sections of the list

    [SerializeField]
    GameObject pieceBtn; // Button prefab

    [SerializeField]
    GameObject piecesList; // Object containing the tree list

    bool xRayActive = false;
    bool isListActive = false;

    // Dictionary to store the childs and subchilds of the model
    Dictionary<Transform, List<Transform>> components = new Dictionary<Transform, List<Transform>>();

    // Start is called before the first frame update
    void Start()
    {
        // Get childs of the model
        foreach (Transform child in transform)
        {
            List<Transform> subChilds = new List<Transform>();

            // Get subchilds of the model
            foreach (Transform subChild in child)
            {
                subChilds.Add(subChild);
            }
            components.Add(child, subChilds);
        }

        // Create buttons for each subchild
        CreateBtnPiece();
    }

    // Method called to reset the scene
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Method called to activate the X-Ray mode
    public void XRayMode()
    {
        xRayActive = !xRayActive;

        // Get the subchilds to change their material
        foreach (KeyValuePair<Transform, List<Transform>> element in components)
        {
            foreach (Transform chld in element.Value)
            {
                if (xRayActive)
                {
                    chld.GetComponent<Renderer>().material = xRayMaterial;
                    chld.GetComponent<MeshPart>().xRayActive = xRayActive;
                }
                else
                {
                    chld.GetComponent<Renderer>().material = normalMaterial;
                    chld.GetComponent<MeshPart>().xRayActive = xRayActive;
                }
            }
        }
    }

    // Method to create a button for each subchild
    private void CreateBtnPiece()
    {
        // Index
        int idx = 0;

        // Create buttons on each list body
        foreach(GameObject body in listBodies)
        {
            foreach (Transform piece in components.ElementAt(idx).Value)
            {
                // Instantiating a new button
                GameObject btn = Instantiate(pieceBtn);
                // Set Parent as the body element
                btn.transform.SetParent(body.transform);
                // Assign the corresponding mesh part to the button
                btn.transform.GetComponent<PieceBtn>().piece = piece.GetComponent<MeshPart>();
                // Set text of the button equal to the part name
                btn.transform.GetComponentInChildren<TextMeshProUGUI>().text = piece.name;

                piece.GetComponent<MeshPart>().correspondingButton = btn;
            }
            idx++;
        }
    }

    // Hide and show the tree list
    public void hideList()
    {
        isListActive = !isListActive;
        piecesList.SetActive(isListActive);

    }
}
