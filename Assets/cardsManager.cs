using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardsManager : MonoBehaviour
{
    public GameObject board;
    public GameObject[] deck_01;
    public GameObject[] deck_02;
    public GameObject[] deck_03;
    public GameObject[] deck_04;
    public GameObject[] deck_05;

    //public float[] codesList = new float[9];
    public List<float> codesList = new List<float>();

    public List<GameObject> boardBag = new List<GameObject>();
    public GameObject playerManager;
    public GameObject bagManager;
    public int level;
    public bool enableRoll;
    public bool startStage;
    public bool boardLock;

    // Start is called before the first frame update
    void Start()
    {
        bagManager = GameObject.Find("bagManager");
        level = playerManager.GetComponent<playerManager>().level;
        boardLock = false;
        enableRoll = true;
        startStage = true;
        Roll();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Roll()
    {
        if (enableRoll == true)
        {
            enableRoll = false;
            spawnPercentage();

        }
    }

    public void lockSystem()
    {
        boardLock = !boardLock;
    }



    public void instantiateCard(int decknumber)
    {
        switch (decknumber)
        {
            case 1:
                //if (boardbag.count < 9)
                //{
                GameObject newcard = (GameObject)Instantiate(deck_01[Random.Range(0, deck_01.Length)], transform.position, Quaternion.identity);
                newcard.transform.parent = board.transform;
                newcard.transform.localScale = new Vector3(1, 1, 1);
                Vector3 positiontemp = newcard.transform.position;
                positiontemp.y = 2.7f;
                newcard.transform.position =positiontemp;

                newcard.GetComponent<card>().code = generateCode();
                boardBag.Add(newcard);


                //print("gerou carta 1");
                //}

                break;
            case 2:
                //if (boardBag.Count < 9)
                //{
                GameObject newcard2 = (GameObject)Instantiate(deck_02[Random.Range(0, deck_01.Length)], transform.position, Quaternion.identity);
                newcard2.transform.parent = board.transform;
                newcard2.transform.localScale = new Vector3(1, 1, 1);
                Vector3 positiontemp2 = newcard2.transform.position;
                positiontemp2.y = 0.7f;
                newcard2.transform.position = positiontemp2;

                newcard2.GetComponent<card>().code = generateCode();
                boardBag.Add(newcard2);
                //}
                print("gerou carta 2");
                break;
            case 3:
                //if (boardBag.Count < 9)
                //{
                GameObject newcard3 = (GameObject)Instantiate(deck_03[Random.Range(0, deck_01.Length)], transform.position, Quaternion.identity);
                newcard3.transform.parent = board.transform;
                newcard3.transform.localScale = new Vector3(1, 1, 1);
                Vector3 positiontemp3 = newcard3.transform.position;
                positiontemp3.y = 0.7f;
                newcard3.transform.position = positiontemp3;
                newcard3.GetComponent<card>().code = generateCode();
                boardBag.Add(newcard3);
                //}
                print("gerou carta 3");
                break;
            case 4:
                //if (boardBag.Count < 9)
                //{
                GameObject newcard4 = (GameObject)Instantiate(deck_04[Random.Range(0, deck_04.Length)], transform.position, Quaternion.identity);
                newcard4.transform.parent = board.transform;
                newcard4.transform.localScale = new Vector3(1, 1, 1);

                newcard4.GetComponent<card>().code = generateCode();
                boardBag.Add(newcard4);
                // }
                print("gerou carta 4");
                break;
            case 5:
                //if (boardBag.Count < 9)
                //{
                GameObject newcard5 = (GameObject)Instantiate(deck_05[Random.Range(0, deck_05.Length)], transform.position, Quaternion.identity);
                newcard5.transform.parent = board.transform;
                newcard5.transform.localScale = new Vector3(1, 1, 1);


                newcard5.GetComponent<card>().code = generateCode();
                boardBag.Add(newcard5);
                //}
                print("gerou carta 5");
                break;
        }
        enableRoll = true;


    }

    public float generateCode()
    {
        float temp = 0f;
        int i = 0;
        int valuesCheck = 0;
        temp = Random.Range(0, 999);
        if (codesList.Count > 0)
        {
            for (i = 0; i < codesList.Count; i++)
            {
                if (codesList[i] == temp)
                {
                    temp = Random.Range(0, 999);
                    i = 0;

                }


            }

        }
        else
        {
            codesList.Add(temp);
            return temp;
        }
        codesList.Add(temp);


        return temp;
    }

    public bool invokePiece(GameObject obj)
    {
        for (int i = 0; i < boardBag.Count; i++)
        {
            if (obj.GetComponent<card>().code == boardBag[i].GetComponent<card>().code)
            {
                print("slot length: " + bagManager.GetComponent<bagManager>().slots.Length);
                for(int j=0; j< bagManager.GetComponent<bagManager>().slots.Length; j++)
                {
                    if (bagManager.GetComponent<bagManager>().slots[j].GetComponent<Slot>().isEmpty == true)
                    {
                        var piece = Instantiate(obj.GetComponent<card>().Prefab, bagManager.GetComponent<bagManager>().slots[j].transform.position, Quaternion.identity);
                        bagManager.GetComponent<bagManager>().slots[j].GetComponent<Slot>().codePiece = obj.GetComponent<card>().code;
                        bagManager.GetComponent<bagManager>().slots[j].GetComponent<Slot>().isEmpty = false;

                        return true;
                    }
                    //else { print("newnhum slot"); }
                }

                return false;
                

            }
        }

        return false;

    }

    public void spawnPercentage()
    {
        //essa funçao chama a funcao probability que chama a funcao instantiateCard 
        float deck01 = 0;
        float deck02 = 0;
        float deck03 = 0;
        float deck04 = 0;
        float deck05 = 0;



        switch (level)
        {
            case 1:
                deck01 = 100;
                deck02 = 0;
                deck03 = 0;
                deck04 = 0;
                deck05 = 0;

                break;

            case 2:
                deck01 = 100;
                deck02 = 0;
                deck03 = 0;
                deck04 = 0;
                deck05 = 0;
                break;
            case 3:
                deck01 = 75;
                deck02 = 25;
                deck03 = 0;
                deck04 = 0;
                deck05 = 0;
                break;
            case 4:
                deck01 = 55;
                deck02 = 30;
                deck03 = 15;
                deck04 = 0;
                deck05 = 0;
                break;
            case 5:
                deck01 = 45;
                deck02 = 33;
                deck03 = 20;
                deck04 = 2;
                deck05 = 0;
                break;
            case 6:
                deck01 = 35;
                deck02 = 35;
                deck03 = 25;
                deck04 = 5;
                deck05 = 0;
                break;
            case 7:
                deck01 = 22;
                deck02 = 35;
                deck03 = 30;
                deck04 = 12;
                deck05 = 1;
                break;
            case 8:
                deck01 = 15;
                deck02 = 25;
                deck03 = 35;
                deck04 = 20;
                deck05 = 5;
                break;
            case 9:
                deck01 = 10;
                deck02 = 15;
                deck03 = 30;
                deck04 = 30;
                deck05 = 15;
                break;
        }
        print("bag length: " + boardBag.Count);
        if (startStage && !boardLock)
        {
            startStage = false;
            print("start");
            //playerManager.GetComponent<playerManager>().gold -= 3;
            probability(deck01, deck02, deck03, deck04, deck05);
        }
        //else if (boardBag.Count < 10 && playerManager.GetComponent<playerManager>().gold > 3)
        else if (playerManager.GetComponent<playerManager>().gold >= 3 && !boardLock)
        {
            print("roll");
            clearAllBag();
            playerManager.GetComponent<playerManager>().gold -= 3;
            probability(deck01, deck02, deck03, deck04, deck05);
        }



    }

    public void clearAllBag()
    {
        print("entrou em clear");
        print("valor de count: " + boardBag.Count);
        int lengthCount = boardBag.Count;

        foreach (GameObject b in boardBag)
        {
            GameObject temp = b;
            Destroy(temp.gameObject);

        }
        boardBag.Clear();

        //for(int i=0; i< lengthCount; i++)
        //{
        //    if (boardBag[i] == null)
        //    {
        //        print("deu merda");
        //    }
        //    else {
        //        GameObject temp = boardBag[i];
        //        boardBag.Remove(temp);
        //        Destroy(temp.gameObject);
        //        print("valor de i: " + i);
        //        }
        //}
    }

    public void probability(float deck01, float deck02, float deck03, float deck04, float deck05)
    {
        float rand = Random.Range(0, 99);
        switch (level)
        {
            case 1:
                for (int i = 0; i < 9; i++)
                {
                    if (rand <= deck01)
                    {
                        instantiateCard(1);
                        rand = Random.Range(0, 100);
                    }
                }
                break;

            case 2:
                for (int i = 0; i < 9; i++)
                {
                    if (rand <= deck01)
                    {
                        instantiateCard(1);
                        rand = Random.Range(0, 100);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < 9; i++)
                {
                    if (rand > deck02 && rand <= deck01)
                    {
                        instantiateCard(1);
                        rand = Random.Range(0, 100);
                    }
                    else if (rand <= deck02)
                    {
                        instantiateCard(2);
                        rand = Random.Range(0, 100);

                    }

                }
                break;
            case 4:
                for (int i = 0; i < 9; i++)
                {
                    if (rand <= deck03)
                    {
                        instantiateCard(3);
                        rand = Random.Range(0, 100);
                    }
                    else
                    if (rand > deck03 && rand <= deck02)
                    {
                        instantiateCard(2);
                        rand = Random.Range(0, 100);
                    }
                    else if (rand > deck02 && rand <= deck01)
                    {
                        instantiateCard(1);
                        rand = Random.Range(0, 100);

                    }

                }
                break;
            case 5:
                for (int i = 0; i < 9; i++)
                {
                    if (rand <= deck04)
                    {
                        instantiateCard(4);
                        rand = Random.Range(0, 100);
                    }
                    else
                    if (rand > deck04 && rand <= deck03)
                    {
                        instantiateCard(3);
                        rand = Random.Range(0, 100);
                    }
                    else if (rand > deck03 && rand <= deck02)
                    {
                        instantiateCard(2);
                        rand = Random.Range(0, 100);

                    }
                    else if (rand > deck02 && rand <= deck01)
                    {
                        instantiateCard(1);
                        rand = Random.Range(0, 100);

                    }

                }
                break;
            case 6:
                for (int i = 0; i < 9; i++)
                {
                    if (rand <= deck04)
                    {
                        instantiateCard(4);
                        rand = Random.Range(0, 100);
                    }
                    else
                    if (rand > deck04 && rand <= deck03)
                    {
                        instantiateCard(3);
                        rand = Random.Range(0, 100);
                    }
                    else if (rand > deck03 && rand <= deck02)
                    {
                        instantiateCard(Random.Range(1, 2));
                        rand = Random.Range(0, 100);

                    }


                }
                break;
            case 7:
                for (int i = 0; i < 9; i++)
                {
                    if (rand <= deck05)
                    {
                        instantiateCard(5);
                        rand = Random.Range(0, 100);
                    }
                    else
                    if (rand > deck05 && rand <= deck04)
                    {
                        instantiateCard(4);
                        rand = Random.Range(0, 100);
                    }
                    else if (rand > deck04 && rand <= deck01)
                    {
                        instantiateCard(1);
                        rand = Random.Range(0, 100);

                    }
                    else if (rand > deck01 && rand <= deck03)
                    {
                        instantiateCard(3);
                        rand = Random.Range(0, 100);

                    }
                    else if (rand > deck03 && rand <= deck02)
                    {
                        instantiateCard(2);
                        rand = Random.Range(0, 100);

                    }

                }
                break;
            case 8:
                for (int i = 0; i < 9; i++)
                {
                    if (rand <= deck05)
                    {
                        instantiateCard(5);
                        rand = Random.Range(0, 100);
                    }
                    else
                    if (rand > deck05 && rand <= deck01)
                    {
                        instantiateCard(1);
                        rand = Random.Range(0, 100);
                    }
                    else if (rand > deck01 && rand <= deck04)
                    {
                        instantiateCard(4);
                        rand = Random.Range(0, 100);

                    }
                    else if (rand > deck04 && rand <= deck02)
                    {
                        instantiateCard(2);
                        rand = Random.Range(0, 100);

                    }
                    else if (rand > deck02 && rand <= deck03)
                    {
                        instantiateCard(4);
                        rand = Random.Range(0, 100);

                    }

                }
                break;
            case 9:
                for (int i = 0; i < 9; i++)
                {
                    if (rand <= deck01)
                    {
                        instantiateCard(1);
                        rand = Random.Range(0, 100);
                    }
                    else
                    if (rand > deck01 && rand <= deck05)
                    {
                        int[] arr = new int[] { 2, 5 };
                        instantiateCard(arr[Random.Range(0, arr.Length)]);
                        rand = Random.Range(0, 100);
                    }
                    else if (rand > deck05 && rand <= deck03)
                    {
                        int[] arr = new int[] { 3, 4 };
                        instantiateCard(arr[Random.Range(0, arr.Length)]);
                        rand = Random.Range(0, 100);
                    }

                }
                break;

        }



    }

    public void removeCardBoard(GameObject obj)
    {
        for (int i = 0; i < boardBag.Count; i++)
        {
            if (obj.GetComponent<card>().code == boardBag[i].GetComponent<card>().code)
            {
                boardBag.RemoveAt(i);

            }
        }


    }

    public void teste()
    {

    }
}
