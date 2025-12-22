using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class TowerMenuButton : MonoBehaviour
{
    public GameObject unit1Prefab;
    public GameObject unit2Prefab;
    public GameObject unit3Prefab;
    public GameObject spawnPoint;
    public TroopManager.UnitType unitType = TroopManager.UnitType.None;
    public Sprite [] buttonImages;
    public RangeTrigger rangeTrigger;

    private GameObject unit;

    public ButtonSound buttonSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if(TroopManager.Instance.selectedUnitType != TroopManager.UnitType.None)
        {

            if(TroopManager.Instance.selectedUnitType == TroopManager.UnitType.Unit1 && TroopManager.Instance.unit1Number>0)
            {
                TroopManager.Instance.unit1Number--;
                giveBackOld();
                unitType = TroopManager.UnitType.Unit1;
                gameObject.GetComponent<Image>().sprite = buttonImages[0];
                gameObject.GetComponent<Image>().color = Color.white;
                unit = Instantiate(unit1Prefab, spawnPoint.transform.position, Quaternion.identity);
                rangeTrigger.AddUnit(unit.GetComponent<Unit>());
                buttonSound.playUnitPlace();
            }
            if(TroopManager.Instance.selectedUnitType == TroopManager.UnitType.Unit2 && TroopManager.Instance.unit2Number>0)
            {
                giveBackOld();
                TroopManager.Instance.unit2Number--;
                unitType = TroopManager.UnitType.Unit2;
                gameObject.GetComponent<Image>().sprite = buttonImages[1];
                gameObject.GetComponent<Image>().color = Color.white;
                unit = Instantiate(unit2Prefab, spawnPoint.transform.position, Quaternion.identity);

                buttonSound.playUnitPlace();
            }
            if(TroopManager.Instance.selectedUnitType == TroopManager.UnitType.Unit3 && TroopManager.Instance.unit3Number>0)
            {
                giveBackOld();
                TroopManager.Instance.unit3Number--;
                unitType = TroopManager.UnitType.Unit3;
                gameObject.GetComponent<Image>().sprite = buttonImages[2];
                gameObject.GetComponent<Image>().color = Color.white;
                unit = Instantiate(unit3Prefab, spawnPoint.transform.position, Quaternion.identity);

                buttonSound.playUnitPlace();
            }
        }

        
    }

    private void giveBackOld()
    {
        if(unitType != TroopManager.UnitType.None)
            {
                if(unitType == TroopManager.UnitType.Unit1)
                {
                    TroopManager.Instance.unit1Number++;
                }
                if(unitType == TroopManager.UnitType.Unit2)
                {
                    TroopManager.Instance.unit2Number++;
                }
                if(unitType == TroopManager.UnitType.Unit3)
                {
                    TroopManager.Instance.unit3Number++;
                }
            }
            Destroy(unit);
        
    }

    public void giveBack()
    {
        giveBackOld();
        unitType = TroopManager.UnitType.None;
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.GetComponent<Image>().color = new Color32(0x36, 0x27, 0x8A, 255);
        buttonSound.playUnitPlace();
    }
}
