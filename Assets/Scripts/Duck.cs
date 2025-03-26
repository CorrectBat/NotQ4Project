using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour, Clickable
{
    private bool mouseHeld;
    private Vector3 offSet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseHeld) {
            Drag();
        }
    }

    void Drag() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition + offSet;
    }
    public void OnClick() {
        mouseHeld = true;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offSet = transform.position - mousePosition;
    }

    public void OnRelease() {
        mouseHeld = false;
    }


}
