using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public class GameManager : MonoBehaviour
{
    private bool isPlaying;

    private State curState;

    public static GameManager instance = null;

    public float score;

    public bool step1_put_clear;
    public int step1_gamcho_num;
    public bool step1_move_gamcho;

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
        curState = State.STEP2;

        step1_gamcho_num = 0;
        step1_put_clear = false;
        step1_move_gamcho = false;

        score = 0;

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

    // Update is called once per frame
    void Update()
    {
        Debug.Log("curState" + curState);
        if(!isPlaying){
            switch(curState){
                case State.START:
                    isPlaying = true;
                    break;
                case State.STEP1:
                    isPlaying = true;
                    StartCoroutine(Step1());
                    break;
                case State.STEP2:
                    isPlaying = true;
                    StartCoroutine(Step2());
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
        //감기에 심하게 걸려 열이 높은 환자가 있어요 올바른 약재를 찾아보세요
        

        //약재를 꺼내서 약연에 넣어보세요 
        yield return new WaitUntil(() => step1_put_clear);
        //넣음
        
        //연알(막대)을 굴려서 약재를 빻아보세요
        //빻음  
        yield return new WaitUntil(() => step1_gamcho_num >= 9);
        //약즙을 탕약기로 옮겨보세요
        //옮김
        yield return new WaitUntil(() => step1_move_gamcho);
        yield return new WaitForSeconds(10.0f); // 10초뒤 종료
        
        isPlaying = false;
        

    }

    IEnumerator Step2(){
        // 플레이어 이동
        // 조명 어둡
        Debug.Log("hi");

        for(int i=0; i<20; i++){
            
            yield return new WaitForSeconds(1f);
            UIManager.instance.Temp_down(); // 20초동안 1초에 1/20 만큼 온도 떨어짐
        }
        isPlaying = false;
        curState = State.STEP3;
        
        if(UIManager.instance.temperature.value >= 0.7f){
            score += 1;
        }

    }

    IEnumerator Step3(){
        yield return new WaitForSeconds(0.1f);

    }
}

