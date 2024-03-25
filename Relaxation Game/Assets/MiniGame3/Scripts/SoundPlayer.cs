using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sound0;
    [SerializeField] AudioClip sound1;
    [SerializeField] AudioClip sound2;
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
        }
    }
}
