using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickerSubmitButton : MonoBehaviour, Clickable
{
    [SerializeField] ColorStation station;
    [SerializeField] Bucket bucket;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void SendDuck() {
        station.SendDuck();
    }
    public void OnClick() {
        if(bucket.GetAmountFilled() > 0) {
            SendDuck();
        }
    }

    public void OnRelease() {

    }
}
