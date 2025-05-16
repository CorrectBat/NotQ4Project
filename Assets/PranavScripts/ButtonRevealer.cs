using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRevealer : MonoBehaviour
{
    public GameObject buttonToReveal; // Assign the button in the inspector
    public float revealDelay = 5f; // Set the time in seconds

    void Start()
    {
        if (buttonToReveal != null)
        {
            buttonToReveal.SetActive(false); // Initially hide the button
            Invoke("RevealButton", revealDelay); // Call RevealButton after the delay
        }
        else
        {
            Debug.LogWarning("ButtonToReveal not assigned. Please assign in the inspector.");
        }
    }

    public void RevealButton()
    {
        if (buttonToReveal != null)
        {
            buttonToReveal.SetActive(true); // Make the button visible
        }
    }
}
