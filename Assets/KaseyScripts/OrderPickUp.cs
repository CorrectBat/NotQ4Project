using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPickUp : MonoBehaviour{
    public Vector3 largeScale;
    public float yPosLargeScale;
    public Vector3 smallScale;
    public float yPosSmallScale;
    public void showOrder(){
        if(transform.localScale == largeScale){
            transform.localScale = smallScale;
            transform.localPosition = new Vector3(transform.localPosition.x, yPosSmallScale, transform.localPosition.z);
        } else{
            transform.localScale = largeScale;
            transform.localPosition = new Vector3(transform.localPosition.x, yPosLargeScale, transform.localPosition.z);
        }
    }
}

