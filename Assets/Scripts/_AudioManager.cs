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
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        //audios = new AudioClip[20];
        audioSource = GetComponent<AudioSource>();
         
    }

    public void Playclip(int num){
        Debug.Log("RHDHHDH");
        audioSource.clip = audios[num];
        audioSource.Play();
    }
    
}
