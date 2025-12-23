using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource audioSource;
    public AudioClip fireBallSound;
    public AudioClip skeletonDeadSound;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayFireBallSound()
    {
        audioSource.PlayOneShot(fireBallSound);
    }

    public void playSkeletonDeadSound()
    {
        audioSource.PlayOneShot(skeletonDeadSound);
    }
}

