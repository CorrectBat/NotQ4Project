using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject duck;
    
    void OnMouseOver()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            if(transform.name == "Tail1Button"){
                duck.name = "Duck_tail1";
            } else if(transform.name == "Tail2Button"){
                duck.name = "Duck_tail2";
            } else if (transform.name == "Tail3Button"){
                duck.name = "Duck_tail3";
            } 
        }
    } 
}
