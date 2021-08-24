using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamCho : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject liquid;

    private int colnum;
    
    private int colnum_max = 10;
    void Start(){
        colnum = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Blade")
        colnum += 1;
        Debug.Log(colnum);
        if(colnum == colnum_max){
            liquid.SetActive(true);
            liquid.transform.parent = null;
            Destroy(gameObject);
            
        }
    }
}
