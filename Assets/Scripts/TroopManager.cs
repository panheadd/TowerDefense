using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TroopManager : MonoBehaviour
{
    public static TroopManager Instance;

    public enum UnitType
    {
    None,
    Unit1,
    Unit2,
    Unit3
    }
    
    public int unit1Number;
    public int unit2Number;
    public int unit3Number;
    public UnitType selectedUnitType;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addTroop1()
    {
        unit1Number++;
    }
    public void addTroop2()
    {
        unit2Number++;
    }
    public void addTroop3()
    {
        unit3Number++;
    }
}
