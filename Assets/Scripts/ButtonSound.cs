using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip clickSound;
    public AudioClip unitSound;
    public AudioClip purchaseSound;
    public AudioClip unitPlace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void PlayUnitSound()
    {
        audioSource.PlayOneShot(unitSound);
    }

    public void playPurchaseSound()
    {
        audioSource.PlayOneShot(purchaseSound);
    }
    public void playUnitPlace()
    {
        audioSource.PlayOneShot(unitPlace);
    }  
}
