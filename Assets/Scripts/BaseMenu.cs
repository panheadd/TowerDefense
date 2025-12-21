using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMenu : MonoBehaviour
{

    public void BuyUnit1()
    {
        if (GoldManager.Instance.SpendGold(10))
        {
            TroopManager.Instance.addTroop1();
        }
    }

    public void BuyUnit2()
    {
        if(GoldManager.Instance.SpendGold(20))
        {

            TroopManager.Instance.addTroop2();
        }

    }

    public void BuyUnit3()
    {
        if(GoldManager.Instance.SpendGold(30))
        {
            TroopManager.Instance.addTroop3();

        }
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}

