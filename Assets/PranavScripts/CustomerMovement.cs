using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float scaleSpeed = 1f; // Adjust for desired scaling speed
    public float targetScale = 100f; // Target scale value
    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, initialScale * targetScale, scaleSpeed * Time.deltaTime);
    }
}
