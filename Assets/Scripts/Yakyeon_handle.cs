using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yakyeon_handle : MonoBehaviour
{
    Transform holder1, holder2;
    void Start(){
        holder1 = transform.GetChild(0); 
        holder2 = transform.GetChild(1);
    }
    // Update is called once per frame
    // void Update()
    // {
    // //   transform.position = (holder1.transform.position + holder2.transform.position) / 2;
    // }
}
