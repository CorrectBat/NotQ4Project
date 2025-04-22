using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, Clickable
{
    [SerializeField] Color materialColor;
    [SerializeField] float needAmount;
    [SerializeField] Bucket bucket;
    [SerializeField] Pourer pourer;
    [SerializeField] DuckColors color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        if(CanPress()) {
            bucket.SetColor(materialColor, color);
            bucket.setNeededAmount(needAmount);
            pourer.SetLiquidColor(materialColor);
        }
    }

    public void OnRelease() {

    }

    public bool CanPress() {
        return !bucket.hasLiquid();
    }
}
