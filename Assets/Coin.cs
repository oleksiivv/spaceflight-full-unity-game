using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float speed=1;

    void Start(){
        speed=0.6f;

        Invoke(nameof(clean), 7);
    }

    void Update()
    {
        transform.position=Vector3.MoveTowards(transform.position,
                                                    new Vector3(transform.position.x,
                                                                -20,
                                                                transform.position.z),0.1f*Time.timeScale*speed*GlobalTimer.timer);
    }

    void clean(){
        Destroy(gameObject);
    }
    
}
