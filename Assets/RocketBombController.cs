using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBombController : MonoBehaviour
{
    bool turnToBeSmall=false;

    public ParticleSystem boomEffect;

    public int speed;

    void Start(){
        Invoke(nameof(clean),5f);
    }
    void OnCollisionEnter(Collision other){
        Destroy(other.gameObject);
    }

    void Update(){
        transform.Translate(new Vector3(0,1,0)/10*speed);

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

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Enemy"){
            boomEffect.Play();

            Destroy(other.gameObject);
            
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag=="Enemy"){
            boomEffect.Play();

            Destroy(other.gameObject);
            
        }
    }
    void OnTriggerStay(Collider other){
        if(other.gameObject.tag=="Enemy"){
            boomEffect.Play();

            Destroy(other.gameObject);
            
        }
    }

}
