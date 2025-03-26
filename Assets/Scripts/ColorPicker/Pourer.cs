using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pourer : MonoBehaviour, Clickable
{
    private float pourProgress;
    private bool mouseHeld;
    private Vector3 initialMousePosition;
    private Vector3 currentMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        if(mouseHeld) {
            OnHeld();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHeld() {
        currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pourProgress = (currentMousePosition.x-initialMousePosition.x)/2;
        Pour();
    }

    void Pour() {
        if(pourProgress >= 1) {
            Debug.Log("Pouring!");
        }
    }

    public void OnClick() {
        mouseHeld = true;
        initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnRelease() {
        mouseHeld = false;
    }
}
