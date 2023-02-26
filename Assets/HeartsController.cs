using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsController : MonoBehaviour
{
    public GameObject[] items;

    public GameObject earth;

    private EarthController earthController;

    public Vector2 instPosition;
    public float yPos,xPos;

    public EnemySpawner spawner;

    void Start(){
        earthController = earth.GetComponent<EarthController>();
    }

    public void startSpawn(){
        Invoke(nameof(startSpawnCall), 10);
    }

    private void startSpawnCall(){
        StartCoroutine(instantiation());
    }

    IEnumerator instantiation(){
        while(true){
            if(EarthController.alive){
                if(earthController.healthValue<100){
                    int id=Random.Range(0, items.Length);
                    var obj = Instantiate(items[id], 
                                new Vector3(xPos,yPos,Random.Range(instPosition.x,instPosition.y)), 
                                items[id].transform.rotation) as GameObject;
                    obj.GetComponent<Heart>().earth=this.earth;
                }

                //if(spawner.startDelay>0.03f)spawner.startDelay-=0.0002f;
            }
            yield return new WaitForSeconds(spawner.startDelay*10);
        }
    }
}
