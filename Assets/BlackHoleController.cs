using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour
{
    bool turnToBeSmall=false;

    void Start(){
        Invoke(nameof(clean),5f);
    }
    void OnCollisionEnter(Collision other){
        Destroy(other.gameObject);
    }

    void Update(){
        transform.Rotate(1,0,0);

        if(turnToBeSmall){
            transform.localScale=Vector3.MoveTowards(transform.localScale,Vector3.zero,0.04f);
        }
    }


    void clean(){
        turnToBeSmall=true;
        Invoke(nameof(destroy),1f);
    }

    void destroy(){
        Destroy(gameObject);
    }
}
