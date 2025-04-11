using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pourer : MonoBehaviour, Clickable
{
    private bool mouseHeld;
    private bool isPouring;
    private float pourFactor = 0.1f;
    [SerializeField] GameObject liquidSprite;
    [SerializeField] Vector3 finalPosition;
    [SerializeField] float rotateAmount;
    [SerializeField] int maxMouseDrag;
    [SerializeField] Bucket bucket;
    // Start is called before the first frame update
    void Start()
    {
        bucket.setNeededAmount(.7f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)) {
            OnRelease();
        }

        if(mouseHeld) {
            OnHeld();
        }
    }

    void OnHeld() {
        Pour();
    }

    void Pour() {
        bucket.fill((float)Math.Pow(bucket.GetAmountFilled()+1, 5)*pourFactor*Time.deltaTime);
        liquidSprite.SetActive(true);
    }

    public void OnClick() {
        Debug.Log("Click");
        mouseHeld = true;
        isPouring = true;
    }

    public void OnRelease() {
        mouseHeld = false;
        isPouring = false;
        liquidSprite.SetActive(false);
    }

    public bool IsPouring() {
        return isPouring;
    }

    public void SetLiquidColor(Color color) {
        liquidSprite.GetComponent<SpriteRenderer>().color = color;
    }

    public Vector3[] GetCorners() {
        Vector3 topRight = GetComponent<Renderer>().transform.TransformPoint(GetComponent<Renderer>().bounds.max);
        Vector3 topLeft = GetComponent<Renderer>().transform.TransformPoint(new Vector3(GetComponent<Renderer>().bounds.max.x, GetComponent<Renderer>().bounds.min.y, 0));
        Vector3 botLeft = GetComponent<Renderer>().transform.TransformPoint(GetComponent<Renderer>().bounds.min);
        Vector3 botRight = GetComponent<Renderer>().transform.TransformPoint(new Vector3(GetComponent<Renderer>().bounds.min.x, GetComponent<Renderer>().bounds.max.y, 0));
        return new Vector3[] { topRight, topLeft, botLeft, botRight };
    }
}
