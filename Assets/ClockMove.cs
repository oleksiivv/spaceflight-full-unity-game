using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMove : MonoBehaviour
{
    private float speed=1;

    void Start(){
        speed=1.3f;

        Invoke(nameof(clean), 7);
    }

    void Update()
    {
        transform.position=Vector3.MoveTowards(transform.position,
                                                    new Vector3(transform.position.x,
                                                                -20,
                                                                transform.position.z),0.1f*Time.timeScale*speed);
    }

    void clean(){
        Destroy(gameObject);
    }
}
