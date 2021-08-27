using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip[] audios;

    public AudioSource audioSource;
    public static _AudioManager instance;



    void Start()
    {
        instance = this;
        audios = new AudioClip[20];
        audioSource = GetComponent<AudioSource>();
    }

    public void playclip(int num){
        audioSource.clip = audios[num];
        audioSource.Play();
    }
    
}
