using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    [Header("status")]
    public int gold;
    public float life;
    public int level;

    [Header("GUI")]
    public Image lifeBar;
    public TextMeshProUGUI gold_counter;
    public TextMeshProUGUI level_counter;
    // Start is called before the first frame update
    void Start()
    {
        //gold = 3;
        life = 100;
        level = 1;
        updateGUI();


    }

    public void updateGUI()
    {
       // lifeBar.fillAmount = life / 100;
        gold_counter.text = gold.ToString();
        level_counter.text = level.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
