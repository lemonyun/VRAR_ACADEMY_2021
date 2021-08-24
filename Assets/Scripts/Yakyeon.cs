using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yakyeon : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "GamCho"){
            int childnum = other.transform.childCount;
            for(int i = 0; i < childnum; i++){
                GameObject ch = other.transform.GetChild(0).gameObject;
                ch.transform.parent = null;
                ch.AddComponent<Rigidbody>();
            }
        }   
    }
}
