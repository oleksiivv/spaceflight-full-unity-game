using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialItemShoot : SpecialItem
{
    public Slider shootTime;

    void Start(){
        base.Start();

        shootTime.maxValue=period;
        shootTime.minValue=0;

        shootTime.value=period;
    }
    public override void choose(){
        if(loading.fillAmount==0 || !loading.gameObject.activeSelf){
            Debug.Log("Instantiate new item");
            
            loading.gameObject.SetActive(true);
            loading.fillAmount=1;

            foreach(var obj in objectToInstantiate)obj.SetActive(true);

            //Invoke(nameof(cleanNewObj),period);
            StartCoroutine(availableShoot());

            StartCoroutine(fill(diff));
        }
    }

    IEnumerator availableShoot(){
        while(shootTime.value>0){
            shootTime.value-=0.01f;
            yield return new WaitForSeconds(0.005f);
        }
        cleanNewObj();
    }

    void cleanNewObj(){
        foreach(var obj in objectToInstantiate)obj.SetActive(false);
    }
}
