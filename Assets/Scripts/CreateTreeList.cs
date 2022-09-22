using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateTreeList : MonoBehaviour
{
    [SerializeField]
    Material xRayMaterial;

    [SerializeField]
    Material normalMaterial;

    bool xRayActive = false;

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
}
