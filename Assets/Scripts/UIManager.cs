using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider temperature;
    public static UIManager instance = null;

    void Start(){
        temperature.value = 0;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }


    public void Temp_up(){
        if(temperature.value < 1.0f){
            temperature.value += 0.1f;
        }
    }

    public void Temp_down(){
        if(temperature.value > 0){
            temperature.value -= 0.1f;
        }
    }
}
