using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public class GameManager : MonoBehaviour
{
    public bool isStep1Done;
    public bool isStep2Done;
    public bool isStep3Done;

    private State curState;

    public static GameManager instance = null;

    public float score;

    public bool step1_put_clear;
    public int step1_gamcho_num;
    public bool step1_move_liquid;
    
    public GameObject yaktang;

    public Transform step1_transform;
    public Transform stpe2_transform;
    public Transform stpe3_transform;
    public Transform yaktang_transform;

    public GameObject space1;
    public GameObject space2;
    public GameObject space3;

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
        isStep1Done = false;
        isStep2Done = false;
        isStep3Done = false;


        curState = State.STEP1;

        step1_gamcho_num = 0;
        step1_put_clear = false;
        step1_move_liquid = false;

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

        StartCoroutine(GameFlow());
    }

    // Update is called once per frame
    IEnumerator GameFlow()
    {

        StartCoroutine(Step1());
        yield return new WaitUntil(() => isStep1Done);
        StartCoroutine(Step2());
        yield return new WaitUntil(() => isStep2Done);
        StartCoroutine(Step3());
        
        
    }

    IEnumerator Step1(){
        yield return new WaitForSeconds(2.0f);
        //감기에 심하게 걸려 열이 높은 환자가 있어요 올바른 약재를 찾아보세요
        

        //약재를 꺼내서 약연에 넣어보세요 
        _AudioManager.instance.Playclip(0);
        yield return new WaitUntil(() => step1_put_clear);
        //넣음
        
        //연알(막대)을 굴려서 약재를 빻아보세요
        //빻음  
        UIManager.instance.ActiveManual(2, true);
        _AudioManager.instance.Playclip(1);
        yield return new WaitUntil(() => step1_gamcho_num >= 9);
        //약즙을 탕약기로 옮겨보세요
        //옮김
        UIManager.instance.ActiveManual(2, false);
        UIManager.instance.ActiveManual(3, true);
        _AudioManager.instance.Playclip(2);
        yield return new WaitUntil(() => step1_move_liquid);
        yield return new WaitForSeconds(10.0f); // 10초뒤 종료
        
        isStep1Done = true;

    }

    IEnumerator Step2(){
        // 플레이어 이동
        // 조명 어둡
        
        yield return new WaitForSeconds(2.0f);
        GameObject player = GameObject.Find("LocalAvatar");
        player.transform.position = stpe2_transform.position;


        Debug.Log("hi");

        _AudioManager.instance.Playclip(3);
        for(int i=0; i<20; i++){
            
            yield return new WaitForSeconds(1f);
            UIManager.instance.Temp_down(); // 20초동안 1초에 1/20 만큼 온도 떨어짐
        }
        isStep2Done = true;
         
        if(UIManager.instance.temperature.value >= 0.7f){
            score += 1;
        }

    }

    IEnumerator Step3(){
        yield return new WaitForSeconds(0.1f);

        yaktang.transform.position = yaktang_transform.position;
        
        GameObject player = GameObject.Find("LocalAvatar");
        player.transform.position = stpe3_transform.transform.position;


    }
}

