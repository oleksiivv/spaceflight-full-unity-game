using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject earth;
    private float speed=1;

    void Start(){
        speed=Random.Range(0.5f, 0.6f);

        Invoke(nameof(clean), 7);
    }

    void Update()
    {
        transform.position=Vector3.MoveTowards(transform.position,
                                                    new Vector3(earth.transform.position.x,
                                                                earth.transform.position.y-10,
                                                                transform.position.z),0.1f*Time.timeScale*speed*GlobalTimer.timer);
    }

    void clean(){
        Destroy(gameObject);
    }
}
