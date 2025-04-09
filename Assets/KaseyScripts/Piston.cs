using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Piston : MonoBehaviour
{
    public GameObject piston;
    public GameObject duck;
    public GameObject timingArrow;
    public GameObject stopButton;
    private bool done = false;
    public int speed;

    public Sprite[] finishedDucks;
    public Sprite failedDuck;

    void Start()
    {

    }

    
    void Update()
    {
        if(!done && duck.transform.position.x > -1 && duck.transform.position.x < 1 && duck.transform.position.y > -2 && duck.transform.position.y < 2){
            //Move Duck
            duck.transform.position = new Vector3(0, -1*(float)1.5, 0);

            //Get Stop Button
            stopButton.SetActive(true);

            //Move piston down
            while(piston.transform.position.y > 0.57)
                piston.transform.position += new Vector3(0, (float)(Time.deltaTime*-0.05), 0);

            //Start timing minigame
            if(timingArrow.transform.position.x <= -9.9)
                speed *= -1;
            else if(timingArrow.transform.position.x >= 9.9)
                speed *= -1;
            timingArrow.transform.position += new Vector3(Time.deltaTime*speed, 0, 0);
        }

        if(done){
            //Get Rid of Stop Button
            stopButton.SetActive(false);

            //Change duck sprite
            if((timingArrow.transform.position.x > -10.5 && timingArrow.transform.position.x<-1.5) || (timingArrow.transform.position.x >1.5 && timingArrow.transform.position.x < 10.5)){
                    duck.GetComponent<SpriteRenderer>().sprite = failedDuck;
            } else if(duck.name.Contains("_tail")){
                int tailNum; Int32.TryParse(duck.name.Substring(duck.name.IndexOf("_tail")+5), out tailNum);
                duck.GetComponent<SpriteRenderer>().sprite = finishedDucks[tailNum-1];
            } else {
                duck.GetComponent<SpriteRenderer>().sprite = failedDuck;
            }
            

            //Move piston up
            while(piston.transform.position.y < 3.5)
                piston.transform.position += new Vector3(0, (float)(Time.deltaTime*0.05), 0);
        }
    }

    public void stopTimeMinigame(){
        done = true;
        speed = 0;
    }
}
