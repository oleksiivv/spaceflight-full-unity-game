using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public GameObject[] items;

    public Vector2 instPosition;
    public float yPos,xPos;

    public void startSpawn(){
        Invoke(nameof(startSpawnCall), 20);
    }

    private void startSpawnCall(){
        StartCoroutine(instantiation());
    }

    IEnumerator instantiation(){
        while(true){
            if(EarthController.alive){
                int id=Random.Range(0, items.Length);
                var obj = Instantiate(items[id], 
                                new Vector3(xPos,yPos,Random.Range(instPosition.x,instPosition.y)), 
                                items[id].transform.rotation) as GameObject;

                //if(spawner.startDelay>0.03f)spawner.startDelay-=0.0002f;
            }
            yield return new WaitForSeconds(Random.Range(25f, 30f));
        }
    }
}
