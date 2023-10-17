using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BaseUI : MonoBehaviour
{
    public GameObject pausePanel,deathPanel;
    public GameObject loadingPanel;

#if UNITY_IOS
    private string gameID="4180650";
#else
    private string gameID="4180651";
#endif


    public static int addCnt=0;

    public AdmobController admob;

    void Start(){
        Application.targetFrameRate = 45;
        Advertisement.Initialize(gameID,false);
    }

    public void pause(){
        Time.timeScale=0;
        pausePanel.SetActive(true);

        if(addCnt%2==1){
            //if(Advertisement.IsReady("Android_Interstitial")){
                Advertisement.Show("Android_Interstitial");
            //}
            // else{
            //     admob.showIntersitionalAd();
            // }
        }
        addCnt++;
    }

    public void resume(){
        Time.timeScale=1;
        pausePanel.SetActive(false);
    }

    public void openScene(int id){
        Time.timeScale=1;

        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(id);
    }

    public void restart(){
        openScene(Application.loadedLevel);
    }
}
