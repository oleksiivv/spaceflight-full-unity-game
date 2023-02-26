using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSwicther : MonoBehaviour
{
    public GameObject[] cars;
    
    public int currId;

    private List<ShopItem> items=new List<ShopItem>();

    public GameObject chooseBtn;
    public GameObject[] buyEquipment;
    public Text[] prices;

    public ParticleSystem buyEffect;

    public Text coinsCurrent;

    public MenuController menu;

    void Start(){
        if(PlayerPrefs.GetInt("first",-1)==-1){
            PlayerPrefs.SetInt("coins",100);
            PlayerPrefs.SetInt("first",1);
        }

        coinsCurrent.text=PlayerPrefs.GetInt("coins").ToString();

        items.Add(new ShopItem(0,000,"original"));
        items.Add(new ShopItem(1,120,"zip"));
        items.Add(new ShopItem(2,200,"rocket"));
        items.Add(new ShopItem(3,250,"tank"));
        items.Add(new ShopItem(4,350,"mega"));

        currId=PlayerPrefs.GetInt("current",0);
        show(currId);

        for(int i=0;i<items.Count;i++){
            prices[i].text=items[i].price.ToString();
        }
    }

    public void next(){
        currId++;
        if(currId>=cars.Length){
            currId=0;
        }

        show(currId);
    }

    public void prev(){
        currId--;
        if(currId<0){
            currId=cars.Length-1;
        }

        show(currId);
    }

    void show(int id){
        hideAll();

        cars[id].SetActive(true);
        
        if(PlayerPrefs.GetInt("Car@"+id.ToString())==1 || id==0){
            buyEquipment[id].SetActive(false);
            chooseBtn.SetActive(true);
        }
        else{
            buyEquipment[id].SetActive(true);
            chooseBtn.SetActive(false);
        }
    }

    void hideAll(){
        foreach(var obj in cars){
            obj.SetActive(false);
        }

        foreach(var eq in buyEquipment){
            eq.SetActive(false);
        }
    }


    ////
    public void choose(){
        PlayerPrefs.SetInt("current",currId);
        menu.openScene(1);
    }

    public void confirmStudy(){
        PlayerPrefs.SetInt("studied",1);
        PlayerPrefs.SetInt("current",currId);
        //StartCoroutine(loadAsync(2));
    }



    public void showAvailable(){
        for(int i=0;i<items.Count;i++){
            if(PlayerPrefs.GetInt("Car@"+i.ToString())==1){
                buyEquipment[i].SetActive(false);
            }
            else{
                buyEquipment[i].SetActive(true);
            }
        }
    }

    public void buy(int id){
        if(PlayerPrefs.GetInt("coins")>=items[id].price){
            PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")-items[id].price);

            items[id].buy();
            show(id);

            buyEffect.Play();
            coinsCurrent.text=PlayerPrefs.GetInt("coins").ToString();
        }
    }
}
