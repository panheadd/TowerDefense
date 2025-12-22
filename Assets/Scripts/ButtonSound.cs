using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip clickSound;
    public AudioClip unitSound;
    public AudioClip purchaseSound;
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
        audioSource.Stop();
        audioSource.clip = unitSound;
        audioSource.time = 1.8f;      
        audioSource.Play();
    }

    public void playPurchaseSound()
    {
        audioSource.PlayOneShot(purchaseSound);
    } 
}
