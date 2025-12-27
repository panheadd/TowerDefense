using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
public class TimeButton : MonoBehaviour
{
    int countForTimeSpeed = 0;
    public TextMeshProUGUI tmpText ;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.Instance.waveStarted)
        {
            if (countForTimeSpeed % 3 == 0)
            {
                tmpText.text = "X 1";
                Time.timeScale = 1.0f;
            }
            else if (countForTimeSpeed % 3 == 1)
            {
                tmpText.text = "X 2";
                Time.timeScale = 2f;
            }else if (countForTimeSpeed % 3 == 2)
            {
                tmpText.text = "X 4";
                Time.timeScale = 4f;
            }
        }
        else
        {
            this.GameObject().SetActive(false);
        }
        
        
    }

    public void Click()
    {
        countForTimeSpeed++;
    }
}
