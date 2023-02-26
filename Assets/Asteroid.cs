using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject earth;
    private int postChanged=0;

    private float speed=1;

    private GameObject hole;

    void Start(){
        postChanged=0;

        speed=Random.Range(1.0f,2.0f);
    }

    void Update(){
        if(postChanged==1){
            transform.position=Vector3.MoveTowards(transform.position,earth.transform.position,0.1f*Time.timeScale*speed*GlobalTimer.timer);
        }
        else if(postChanged==0){
            transform.position=Vector3.MoveTowards(transform.position,
                                                    new Vector3(earth.transform.position.x,
                                                                earth.transform.position.y,
                                                                transform.position.z),0.1f*Time.timeScale*speed*GlobalTimer.timer);
        }
        else if(hole!=null){
            transform.position=Vector3.MoveTowards(transform.position,hole.transform.position-new Vector3(1,0,0),0.1f*Time.timeScale*speed*GlobalTimer.timer);
        }
        else if(hole==null){
            postChanged=0;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="AsteroidChanger"){
            postChanged=1;
        }
        if(other.gameObject.tag=="BlackHole"){
            postChanged=2;
            hole=other.gameObject;
            Invoke(nameof(clean),2f);
        }
    }

    void clean(){
        Destroy(gameObject);
    }
}
