using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketCollisionsController : MonoBehaviour
{
    public ParticleSystem asteroidCollisionEffect;
    public Text score,best;
    private int scoreCnt;

    public GameObject newRecordPanel;

    private int showBestScore=0;

    public EarthController earth;

    public CoinsController coinsController;

    void Start(){
        showBestScore=0;

        scoreCnt=0;
        score.text="Score: 000";

        best.text="Best: "+PlayerPrefs.GetInt("best").ToString();

        GlobalTimer.timer = 1f;
    }


    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Enemy"){
            asteroidCollisionEffect.Play();

            Destroy(other.gameObject);
            scoreCnt++;
            score.text="Score: "+scoreCnt.ToString();

            if(scoreCnt>PlayerPrefs.GetInt("best") && PlayerPrefs.GetInt("best",0)!=0 && showBestScore==0){
                newRecordPanel.SetActive(true);
                Invoke(nameof(cleanNewRecordPanel),2f);

                showBestScore=1;
            }

            if(scoreCnt>PlayerPrefs.GetInt("best")){
                PlayerPrefs.SetInt("best",scoreCnt);

                best.text="Best: "+PlayerPrefs.GetInt("best").ToString();

                showBestScore=1;
            }

            
        }
        else if(other.gameObject.tag.ToLower().Equals("heart")){
            var particle = other.gameObject.transform.GetChild(0).transform.gameObject;

            particle.transform.parent = null;
            particle.GetComponent<ParticleSystem>().Play();

            Destroy(other.gameObject);

            //earth.receiveHill(10);

            if(other.gameObject.name.ToLower().Contains("water")){
                earth.receiveHill(5);
            }
            else{
                earth.receiveHill(10);
            }
        }
        else if(other.gameObject.tag.ToLower().Equals("coin")){
            var particle = other.gameObject.transform.GetChild(0).transform.gameObject;

            particle.transform.parent = null;
            particle.GetComponent<ParticleSystem>().Play();

            Destroy(other.gameObject);

            coinsController.receiveCoins(5);
        }
        else if(other.gameObject.tag.ToLower().Equals("clock")){
            var particle = other.gameObject.transform.GetChild(0).transform.gameObject;

            particle.transform.parent = null;
            particle.GetComponent<ParticleSystem>().Play();

            Destroy(other.gameObject);

            startTimer();
        }
    }

    void cleanNewRecordPanel(){
        newRecordPanel.SetActive(false);
    }

    public GameObject clockIcon;

    void startTimer(){
        GlobalTimer.timer = 0.2f;
        clockIcon.SetActive(true);

        Invoke(nameof(stopTimer), 8);
    }

    void stopTimer(){
        GlobalTimer.timer = 1f;

        clockIcon.SetActive(false);
    }
}
