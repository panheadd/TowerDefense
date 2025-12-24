using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public WaveManager waveManager;
    public GameObject backgroundMusic;
    public GameObject backgroundActionMusic;
    public GameObject readyButton;
    public GameObject troopMenu;
    public static GameManager Instance;
    public bool waveStarted = false;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startWave()
    {
        waveStarted = true;
        backgroundMusic.SetActive(false);
        backgroundActionMusic.SetActive(true);
        readyButton.SetActive(false);
        troopMenu.SetActive(false);
        StartCoroutine(waveManager.SpawnWave());
    }
}
