using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yaktanggi : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        
        if(other.tag == "Liquid"){
            GameManager.instance.step1_move_liquid = true;
        }
        
    }
}
