using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public OVRScreenFade ovfade;
    
    public static CameraManager instance;

    void Start(){

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        ovfade = GetComponent<OVRScreenFade>();
    }

    public void FadeIn(){
        ovfade.FadeIn();
    }

    public void FadeOut(){
        ovfade.FadeOut();
    }




}
