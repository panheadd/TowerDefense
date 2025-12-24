using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int waveNo= 1;
    public WaveManager wave1;
    public WaveManager wave2;
    public WaveManager wave3;
    public WaveManager wave3_1;
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
        if (!waveStarted)
            return;

        checkWaveEnd();
    }

    public void startWave()
    {
        if(waveNo == 1)
        {
            startWave1();
            waveNo++;
            return;
        }
        if(waveNo == 2)
        {
            startWave2();
            waveNo++;
            return;
        }
        if(waveNo == 3)
        {
            startWave3();
            waveNo++;
            return;
        }
        
    }

    public void startWave1()
    {
        waveStarted = true;
        backgroundMusic.SetActive(false);
        backgroundActionMusic.SetActive(true);
        readyButton.SetActive(false);
        troopMenu.SetActive(false);
        StartCoroutine(wave1.SpawnWave());
    }

    public void startWave2()
    {
        waveStarted = true;
        backgroundMusic.SetActive(false);
        backgroundActionMusic.SetActive(true);
        readyButton.SetActive(false);
        troopMenu.SetActive(false);
        StartCoroutine(wave2.SpawnWave());
    }
    public void startWave3()
    {
        waveStarted = true;
        backgroundMusic.SetActive(false);
        backgroundActionMusic.SetActive(true);
        readyButton.SetActive(false);
        troopMenu.SetActive(false);
        StartCoroutine(StartWave3Sequence());
    }

    void checkWaveEnd()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            endWave();
        }
        {
            
        }
    }

    void endWave()
    {
        backgroundMusic.SetActive(true);
        backgroundActionMusic.SetActive(false);
        readyButton.SetActive(true);
        troopMenu.SetActive(true);
        waveStarted = false;
        if (waveNo == 2)
        {
            GoldManager.Instance.addGold(50);
        }
        if (waveNo == 3)
        {
            GoldManager.Instance.addGold(50);
        }
    }

    IEnumerator StartWave3Sequence()
{
    // İlk wave bitsin
    yield return StartCoroutine(wave3.SpawnWave());

    // İlk wave TAMAMLANINCA ikinci başlasın
    yield return StartCoroutine(wave3_1.SpawnWave());
}
}
