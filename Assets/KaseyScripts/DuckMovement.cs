using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour, Clickable
{
    private bool mouseHeld;
    private Vector3 offSet;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(mouseHeld) {
            Drag();
        }
    }

    void OnMouseOver()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            OnClick();
        }
    }

    void Drag() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition + offSet;
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            OnRelease();
        }
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

