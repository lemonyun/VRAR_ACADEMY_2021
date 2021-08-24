using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPlaying;

    private State curState;

    private enum State
    {
        START,
        STEP1,
        STEP2,
        STEP3,
        END,
    }


    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;
        curState = State.START;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlaying){
            switch(curState){
                case State.START:
                    isPlaying = true;
                    break;
                case State.STEP1:
                    isPlaying = true;
                    StartCoroutine(Step1);
                    break;
                case State.STEP2:
                    isPlaying = true;
                    break;
                case State.STEP3:
                    isPlaying = true;
                    break;
                case State.END:
                    break;  
            }
        }
    }

    IEnumerator Step1(){
        yield return new WaitForSeconds(0.1f);
        
    }
}
