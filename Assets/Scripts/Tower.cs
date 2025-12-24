using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    public ButtonSound buttonSound;

    public GameObject towerMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.waveStarted)
            return;
            
        towerMenuUI.SetActive(true);
        buttonSound.PlaySound();
    }
}
