using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sound0;
    [SerializeField] AudioClip sound1;
    [SerializeField] AudioClip sound2;
    [SerializeField] AudioClip sound3;
    [SerializeField] AudioClip sound4;
    [SerializeField] AudioClip sound5;
    [SerializeField] AudioClip sound6;
    [SerializeField] AudioClip sound7;
    [SerializeField] AudioClip sound8;
    [SerializeField] int soundClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundClip(int soundClip)
    {
        switch (soundClip)
        {
            case 0:
                audioSource.clip = sound0;
                audioSource.Play();
                break;
            case 1:
                audioSource.clip = sound1;
                audioSource.Play();
                break;
            case 2:
                audioSource.clip = sound2;
                audioSource.Play();
                break;
            case 3:
                audioSource.clip = sound3;
                audioSource.Play();
                break;
            case 4:
                audioSource.clip = sound4;
                audioSource.Play();
                break;
            case 5:
                audioSource.clip = sound5;
                audioSource.Play();
                break;
            case 6:
                audioSource.clip = sound6;
                audioSource.Play();
                break;
            case 7:
                audioSource.clip = sound7;
                audioSource.Play();
                break;
            case 8:
                audioSource.clip = sound8;
                audioSource.Play();
                break;
        }
    }
}
