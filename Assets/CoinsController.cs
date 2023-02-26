using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour
{
    public Text coins;

    void Start(){
        Show();
    }

    void Show(){
        coins.text = PlayerPrefs.GetInt("coins", 0).ToString();
    }

    public void receiveCoins(int n){
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + n);

        Show();
    }
}
