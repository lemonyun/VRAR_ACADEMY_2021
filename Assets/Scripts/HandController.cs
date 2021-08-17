using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    Animator controller;

    float aa;
    public Hand hand;
    void Awake()
    {

    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        if (ARAVRInput.GetDown(ARAVRInput.Button.HandTrigger, ARAVRInput.Controller.LTouch))
        {
            aa = 1.0f;
        }
        hand.SetGrip(aa);
        //hand.SetTrigger();

    }
}
