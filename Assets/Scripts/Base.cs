using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public GameObject baseMenuUI;
    public ButtonSound buttonSound;
    public GameObject info;

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
        info.SetActive(false);
        if (GameManager.Instance.waveStarted)
            return;
        baseMenuUI.SetActive(true);
        buttonSound.PlaySound();   
    }
}
