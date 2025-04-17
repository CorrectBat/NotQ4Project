using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;

public class Piston : MonoBehaviour
{
    public GameObject piston;
    public GameObject duck;
    public GameObject timingArrow;
    public GameObject stopButton;
    private bool done = false;
    public int speed;

    public Sprite[] finishedDucks;
    public TailShapes[] tailShapes;
    public Sprite failedDuck;
    [SerializeField] TailArea tailArea;
    void Update()
    {
        if(duck == null) {
            duck = tailArea.GetDuckObject();
            return;
        }

        if(!done && duck.transform.position.x > -1 && duck.transform.position.x < 1 && duck.transform.position.y > -2 && duck.transform.position.y < 2){
            //Move Duck
            duck.transform.position = new Vector3(0, -1*(float)1.5, 0);

            //Get Stop Button
            //stopButton.SetActive(true);

            //Move piston down (No brackets #1)
            while(piston.transform.position.y > 0.57)
                piston.transform.position += new Vector3(0, (float)(Time.deltaTime*-0.05), 0);

            //Start timing minigame (No brackets #2)
            if(timingArrow.transform.localPosition.x <= -8.5)
                speed *= -1;
            else if(timingArrow.transform.localPosition.x >= 7.25)
                speed *= -1;
            timingArrow.transform.position += new Vector3(Time.deltaTime*speed, 0, 0);
        }

        if(done){
            //Get Rid of Stop Button
            //stopButton.SetActive(false);

            //Change duck sprite (Yay brackets)
            if((timingArrow.transform.position.x > -10.5 && timingArrow.transform.position.x<-1.5) || (timingArrow.transform.position.x >1.5 && timingArrow.transform.position.x < 10.5)){
                    duck.GetComponent<SpriteRenderer>().sprite = failedDuck;
                    duck.GetComponent<LiquidDuck>().SetTailShape(TailShapes.failed);
            } else if(duck.name.Contains("_tail")){
                int tailNum; /*Kasey why did you put this in one line*/ Int32.TryParse(duck.name.Substring(duck.name.IndexOf("_tail")+5), out tailNum);
                duck.transform.localScale = new Vector3(8.3f, 8.3f, 1);
                duck.transform.localPosition = new Vector3(duck.transform.localPosition.x, -3.75f, duck.transform.localPosition.z);
                duck.GetComponent<SpriteRenderer>().sprite = finishedDucks[tailNum-1];
                duck.GetComponent<LiquidDuck>().SetTailShape(tailShapes[tailNum-1]);
            } else {
                duck.GetComponent<SpriteRenderer>().sprite = failedDuck;
                duck.GetComponent<LiquidDuck>().SetTailShape(TailShapes.failed);
            }
            
            //Move piston up (No brackets #3, how dare you not use brackets ):< )
            while(piston.transform.position.y < 3.5)
                piston.transform.position += new Vector3(0, (float)(Time.deltaTime*0.05), 0);
            
        }
    }

    void OnMouseOver()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            stopTimeMinigame();
        }
    } 

    public void stopTimeMinigame(){
        done = true;
        speed = 0;
    }

    public void Empty() {
        duck = null;
        done = false;
        speed = 20;
    }
}
