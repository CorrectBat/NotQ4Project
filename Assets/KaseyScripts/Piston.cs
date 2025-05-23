using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    public Text OrderScoreText;

    void Update()
    {
        if(!done && duck.transform.position.x > -1 && duck.transform.position.x < 1 && duck.transform.position.y > -2 && duck.transform.position.y < 2){
            //Move Duck
            duck.transform.position = new Vector3(0, -1*(float)1.5, 0);

            //Get Stop Button
            //stopButton.SetActive(true);

            //Move piston down
            piston.transform.position = new Vector3(piston.transform.position.x, 0.55f, piston.transform.position.z);

            //Start timing minigame
            if(timingArrow.transform.localPosition.x <= -8.5)
                speed *= -1;
            else if(timingArrow.transform.localPosition.x >= 7.25)
                speed *= -1;
            timingArrow.transform.position += new Vector3(Time.deltaTime*speed, 0, 0);
        }

        if(done){
            //Get Rid of Stop Button
            //stopButton.SetActive(false);

            //Change duck sprite
            if((timingArrow.transform.position.x > -10.5 && timingArrow.transform.position.x<-1.5) || (timingArrow.transform.position.x >1.5 && timingArrow.transform.position.x < 10.5)){
                    duck.GetComponent<SpriteRenderer>().sprite = failedDuck;
            } else if(duck.name.Contains("_tail")){
                int tailNum; Int32.TryParse(duck.name.Substring(duck.name.IndexOf("_tail")+5), out tailNum);
                duck.transform.localScale = new Vector3(8.3f, 8.3f, 1);
                duck.transform.localPosition = new Vector3(duck.transform.localPosition.x, -3.75f, duck.transform.localPosition.z);
                duck.GetComponent<SpriteRenderer>().sprite = finishedDucks[tailNum-1];
            } else {
                duck.GetComponent<SpriteRenderer>().sprite = failedDuck;
            }
            
            //Move piston up
            piston.transform.position = new Vector3(piston.transform.position.x, 4.75f, piston.transform.position.z);
            //while(piston.transform.position.y < 3.5)
            //    piston.transform.position += new Vector3(0, (float)(Time.deltaTime*0.05), 0);
        }

        getScoreTailStation();
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

    public void getScoreTailStation(){
        //Get score
        int score = 0; 
        if(duck.GetComponent<SpriteRenderer>().sprite == failedDuck){
            if(timingArrow.transform.localPosition.x <= -4.6 || timingArrow.transform.localPosition.x > 3.4) {
                score = 0;
            } else if (timingArrow.transform.localPosition.x <= -1.8 || timingArrow.transform.localPosition.x > 3.4){
                score = 25;
            } else{
                score = 50;
            }
        } else{
            score = 100;
        }

        //Set Score to UI
        OrderScoreText.text = score+"%";
    }

    public void Empty() {

    }
}
