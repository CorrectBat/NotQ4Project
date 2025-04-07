using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Text;

public class ChangeText : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        int day = 1;
        text = $"Day {day}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
