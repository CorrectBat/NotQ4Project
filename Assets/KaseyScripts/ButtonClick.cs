using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    //public Button TimerStopButton;
    public GameObject duck;

    public void tail1ButtonClick(){
        duck.name = "Duck_tail1";
    }

    public void tail2ButtonClick(){
        duck.name = "Duck_tail2";
    }

    public void tail3ButtonClick(){
        duck.name = "Duck_tail3";
    }

    public void testing(){
        Debug.Log("testing");
    }
}
