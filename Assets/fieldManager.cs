using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldManager : MonoBehaviour
{
    public List<GameObject> fields = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showFields()
    {
        foreach (GameObject b in fields)
        {
            b.SetActive(true);

        }
    }

    public void hideFields()
    {
        foreach (GameObject b in fields)
        {
            b.SetActive(false);

        }
    }
}
