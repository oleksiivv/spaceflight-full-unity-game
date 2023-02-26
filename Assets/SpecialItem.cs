using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialItem : MonoBehaviour
{
    public Image loading;

    public GameObject player;
    public GameObject[] objectToInstantiate;

    public float diff=0.01f;
    public float period;

    protected void Start(){
        loading.gameObject.SetActive(true);
        loading.fillAmount=1;

        StartCoroutine(fill(diff*10));
    }

    public virtual void choose(){
        if(loading.fillAmount==0 || !loading.gameObject.activeSelf){
            Debug.Log("Instantiate new item");
            
            loading.gameObject.SetActive(true);
            loading.fillAmount=1;

            foreach(var obj in objectToInstantiate)Instantiate(obj,obj.transform.position,obj.transform.rotation);
            //Invoke(nameof(cleanNewObj),period);

            StartCoroutine(fill(diff));
        }
    }

    protected IEnumerator fill(float diffp){
        while(loading.fillAmount>0){
            loading.fillAmount-=diffp;

            yield return new WaitForSeconds(0.03f);
        }

        loading.fillAmount=0;
        loading.gameObject.SetActive(false);
    }


    // void cleanNewObj(){
    //     foreach(var obj in objectToInstantiate)obj.SetActive(true);
    // }
}
