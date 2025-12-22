using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseMenu : MonoBehaviour
{
    public ButtonSound buttonSound;
    public Button button1;
    public Button button2;
    public Button button3;

    public void BuyUnit1()
    {
        if (GoldManager.Instance.SpendGold(10))
        {
            TroopManager.Instance.addTroop1();
            HighlightButton(button1);
            buttonSound.playPurchaseSound();
        }
        
    }

    public void BuyUnit2()
    {
        if(GoldManager.Instance.SpendGold(20))
        {

            TroopManager.Instance.addTroop2();
            HighlightButton(button2);
            buttonSound.playPurchaseSound();

        }

    }

    public void BuyUnit3()
    {
        if(GoldManager.Instance.SpendGold(30))
        {
            TroopManager.Instance.addTroop3();
            HighlightButton(button3);
            buttonSound.playPurchaseSound();

        

        }

    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }

    public void HighlightButton(Button button)
    {
        StartCoroutine(HighlightRoutine(button));
    }

    IEnumerator HighlightRoutine(Button button)
    {
        Image img = button.image;

        Color originalColor = img.color; 
        img.color = Color.yellow;         

        yield return new WaitForSeconds(0.5f);

        img.color = originalColor;
    }
}

