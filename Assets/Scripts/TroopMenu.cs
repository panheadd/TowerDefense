using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TroopMenu : MonoBehaviour
{
    public TMP_Text [] buttonGoldTexts;
    public Image [] borderImages;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        buttonGoldTexts[0].text = TroopManager.Instance.unit1Number.ToString();
        buttonGoldTexts[1].text = TroopManager.Instance.unit2Number.ToString();
        buttonGoldTexts[2].text = TroopManager.Instance.unit3Number.ToString();

        if(TroopManager.Instance.unit1Number <= 0)
        {
            buttonGoldTexts[0].color = Color.red;
        }
        else
        {
            buttonGoldTexts[0].color = Color.white;
        }
        if(TroopManager.Instance.unit2Number <= 0)
        {
            buttonGoldTexts[1].color = Color.red;
        }
        else
        {
            buttonGoldTexts[1].color = Color.white;
        }
        if(TroopManager.Instance.unit3Number <= 0)
        {
            buttonGoldTexts[2].color = Color.red;
        }
        else
        {
            buttonGoldTexts[2].color = Color.white;
        }
    }

    public void selectUnit1()
    {
        TroopManager.Instance.selectedUnitType = TroopManager.UnitType.Unit1;
        borderImages[0].color = Color.yellow;
        borderImages[1].color = Color.white;
        borderImages[2].color = Color.white;
    }
    public void selectUnit2()
    {
        TroopManager.Instance.selectedUnitType = TroopManager.UnitType.Unit2;
        borderImages[0].color = Color.white;
        borderImages[1].color = Color.yellow;
        borderImages[2].color = Color.white;
    }
    public void selectUnit3()
    {
        TroopManager.Instance.selectedUnitType = TroopManager.UnitType.Unit3;
        borderImages[0].color = Color.white;
        borderImages[1].color = Color.white;
        borderImages[2].color = Color.yellow;
    }
}
