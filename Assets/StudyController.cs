using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyController : MonoBehaviour
{
    public GameObject[] studyPanels;
    public EnemySpawner spawner;

    public void closeAll(){
        foreach(var panel in studyPanels)panel.SetActive(false);
    }

    public void next(int current){
        closeAll();

        if(current<studyPanels.Length){
            studyPanels[current+1].SetActive(true);
        }
    }

    public void finish(){
        closeAll();
        PlayerPrefs.SetInt("studied",1);
        spawner.startGame();
    }
}
