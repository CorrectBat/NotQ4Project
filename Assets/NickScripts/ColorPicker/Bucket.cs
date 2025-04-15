using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    private float filledAmount = 0;
    private float neededAmount;
    [SerializeField] float fillFactor;
    [SerializeField] Pourer pourer;
    private Transform liquid;
    private SpriteRenderer liquidSprite;
    private Transform needLine;

    // Start is called before the first frame update
    void Start()
    {
        liquid = transform.GetChild(0).transform;
        liquidSprite = liquid.GetChild(0).GetComponent<SpriteRenderer>();
        needLine = transform.GetChild(1).transform;
        Debug.Log(needLine);
        liquid.transform.localScale = new Vector3(1, 0, 1);
        liquid.gameObject.SetActive(true);
    }

    public float GetAmountFilled() {
        return filledAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if(pourer.IsPouring() && filledAmount <=1) {
            liquid.transform.localScale = new Vector3(1, filledAmount*146, 1);
        }

        if(neededAmount < filledAmount) {
            Debug.Log("Overfilled!");
        }
    }
    public void setNeededAmount(float amount) {
        neededAmount = amount;
        needLine = transform.GetChild(1).transform;
        needLine.localPosition = new Vector3(0, (float)(amount*.3293 -.3543), 0);
    }

    public void fill(float amount) {
        filledAmount += amount*fillFactor;
    }

    public void SetColor(Color color) {
        liquidSprite.color = color;
    }

    public bool hasLiquid() {
        return filledAmount > 0;
    }

    public float GetScore() {
        if(Math.Abs((neededAmount-filledAmount)/filledAmount) < .01) {
            return 100;
        }  else {
            return (neededAmount-filledAmount)/filledAmount*100;
        }
    }
}
