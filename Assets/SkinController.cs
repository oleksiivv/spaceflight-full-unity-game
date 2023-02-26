using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    public GameObject[] defaultCar;

    public GameObject[] cars;


    void Start(){
        if(PlayerPrefs.GetInt("current",0)==0){
            foreach(var car in cars){
                car.SetActive(false);
            }

            foreach(var detail in defaultCar){
                detail.SetActive(true);
            }
        }
        else{
            foreach(var detail in defaultCar){
                detail.SetActive(false);
            }

            cars[PlayerPrefs.GetInt("current")-1].SetActive(true);
        }
    }
}
