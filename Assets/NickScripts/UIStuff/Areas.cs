using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Areas : MonoBehaviour
{
    [SerializeField] GameObject[] areas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchOff() {
        foreach(GameObject area in areas) {
            area.SetActive(false);
        }
    }

    public void Switch(GameObject area) {
        Debug.Log("Click!");
        SwitchOff();
        area.SetActive(true);
    }
}
