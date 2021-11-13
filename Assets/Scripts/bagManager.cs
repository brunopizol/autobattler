using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagManager : MonoBehaviour
{
    public GameObject[] slots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int returnEmptySlot()
    {
        for(int i=0; i<slots.Length; i++)
        {
            if (slots[i].GetComponent<Slot>().isEmpty == true)
            {
                print("valord e slot: " + i);
                return i;
                
            }
        }

        return 99;
    }
}
