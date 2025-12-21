using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance;
    public int gold = 500;
    public TMP_Text goldText;
    public TMP_Text [] button1GoldTexts;



    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        goldText.text = gold.ToString();
        for(int i = 0; i < button1GoldTexts.Length; i++)
        {
            if(gold < int.Parse(button1GoldTexts[i].text))
            {
                button1GoldTexts[i].color = Color.red;
            }
            else
            {
                button1GoldTexts[i].color = Color.white;
            }
        }
    } 

    public bool SpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            return true;
        }

        return false;
    }
}

