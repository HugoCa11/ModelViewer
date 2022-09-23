using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreateTreeList : MonoBehaviour
{
    [SerializeField]
    Material xRayMaterial;

    [SerializeField]
    Material normalMaterial;

    [SerializeField]
    List<GameObject> listBodies;

    [SerializeField]
    GameObject pieceBtn;

    [SerializeField]
    GameObject piecesList;

    bool xRayActive = false;
    bool isListActive = false;

    Dictionary<Transform, List<Transform>> components = new Dictionary<Transform, List<Transform>>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            //child is your child transform
            List<Transform> subChilds = new List<Transform>();

            foreach (Transform subChild in child)
            {
                subChilds.Add(subChild);
            }
            components.Add(child, subChilds);
        }
        CreateBtnPiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void XRayMode()
    {
        xRayActive = !xRayActive;

        foreach (KeyValuePair<Transform, List<Transform>> element in components)
        {
            //Debug.Log($"Key:- {element.Key.name}");
            foreach (Transform chld in element.Value)
            {
                if (xRayActive)
                {
                    chld.GetComponent<Renderer>().material = xRayMaterial;
                }
                else
                {
                    chld.GetComponent<Renderer>().material = normalMaterial;
                }
                //Debug.Log($"Value:- {chld.name}");
                
            }
        }
    }

    private void CreateBtnPiece()
    {
        int idx = 0;
        foreach(GameObject body in listBodies)
        {
            foreach (Transform piece in components.ElementAt(idx).Value)
            {
                GameObject btn = Instantiate(pieceBtn);
                btn.transform.SetParent(body.transform);
                btn.transform.GetComponent<PieceBtn>().piece = piece.GetComponent<MeshPart>();
                btn.transform.GetComponentInChildren<TextMeshProUGUI>().text = piece.name;
            }
            idx++;
        }
    }

    public void hideList()
    {
        isListActive = !isListActive;
        piecesList.SetActive(isListActive);

    }
}
