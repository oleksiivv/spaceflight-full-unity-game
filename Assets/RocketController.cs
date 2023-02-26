using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketController : MonoBehaviour
{
    public Vector2 dx;
    public Slider dxSlider;
    public ParticleSystem flyDust;
    // Start is called before the first frame update
    void Start()
    {
        dxSlider.minValue=dx[0];
        dxSlider.maxValue=dx[1];

        dxSlider.value=(dx[0]+dx[1])/2;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EarthController.alive){
            gameObject.transform.eulerAngles=new Vector3(gameObject.transform.eulerAngles.x,0,(dxSlider.value/2.2f+1f)*-30f-60f);
            gameObject.transform.position=new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,dxSlider.value);
        }
        else{
            flyDust.Stop();
        }
    }
}
