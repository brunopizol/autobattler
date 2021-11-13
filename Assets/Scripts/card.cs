using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class card : MonoBehaviour
{
    public TextMeshProUGUI atk_stat;
    public TextMeshProUGUI def_stat;
    public TextMeshProUGUI cost_stat;
    public TextMeshProUGUI type_stat;
    public float code;
    [Header("settings")]
    public int atk;
    public int def;
    public int cost;
    public string type;
    public GameObject Prefab;
    public GameObject bagManager;
    public GameObject playermanager;
    public GameObject cardManager;

    // Start is called before the first frame update
    void Start()
    {
        startValues();
        cardManager = GameObject.FindGameObjectWithTag("cardManager");
        bagManager = GameObject.FindGameObjectWithTag("bagManager");
        playermanager = GameObject.FindGameObjectWithTag("playerManager");

    }

    public void startValues()
    {
        //atk = Int32.Parse(atk_stat.text);
        //def = Int32.Parse(def_stat.text);
        //cost = Int32.Parse(cost_stat.text);
        atk_stat.text = atk.ToString();
        def_stat.text = def.ToString();
        cost_stat.text = cost.ToString();
        type_stat.text = type;

    }



    public void invokePiece()
    {

        if ((playermanager.GetComponent<playerManager>().gold - cost) >= 0)
        {


            if (cardManager.GetComponent<cardsManager>().invokePiece(this.gameObject))
            {
                playermanager.GetComponent<playerManager>().gold -= cost;
                playermanager.GetComponent<playerManager>().updateGUI();
                cardManager.GetComponent<cardsManager>().removeCardBoard(this.gameObject);
                Destroy(this.gameObject, 0.25f);
            }
        }
        


    }


    // Update is called once per frame
    void Update()
    {

    }
}
