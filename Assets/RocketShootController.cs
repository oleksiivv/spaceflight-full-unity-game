using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShootController : MonoBehaviour
{
    public GameObject bullet;

    public void shoot(){
        Instantiate(bullet,gameObject.transform.position,bullet.transform.rotation);
    }
}
