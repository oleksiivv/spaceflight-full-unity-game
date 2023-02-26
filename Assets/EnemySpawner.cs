using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Vector2 instPosition;
    public float yPos,xPos;
    public float startDelay;

    public GameObject[] enemies;

    public GameObject earth;

    public Text startCounter;
    private int cnt=3;

    public StudyController study;

    public HeartsController heartsController;

    public CoinController coinController;

    public TimerController timer;


    void Start(){

        if(PlayerPrefs.GetInt("studied")==1){
            startCounter.gameObject.SetActive(true);
            StartCoroutine(startCnt());
        }
        else{
            study.next(-1);
        }
    }

    public void startGame(){
        startCounter.gameObject.SetActive(true);
        StartCoroutine(startCnt());
    }


    IEnumerator startCnt(){
        while(cnt>=0){
            if(cnt==0){
                startCounter.text = "Go!";
            }
            else{
                startCounter.text=cnt.ToString();
            }
            yield return new WaitForSeconds(1);

            cnt--;
        }
        startCounter.gameObject.SetActive(false);
        StartCoroutine(instantiation());
        heartsController.startSpawn();
        coinController.startSpawn();
        timer.startSpawn();
    }

    IEnumerator instantiation(){
        while(true){
            if(EarthController.alive){
                int id=Random.Range(0,enemies.Length);
                var obj = Instantiate(enemies[id], 
                                new Vector3(xPos,yPos,Random.Range(instPosition.x,instPosition.y)), 
                                enemies[id].transform.rotation) as GameObject;
                obj.GetComponent<Asteroid>().earth=this.earth;

                if(startDelay>0.03f)startDelay-=0.0002f;
            }
            yield return new WaitForSeconds(startDelay);
        }
    }
}
