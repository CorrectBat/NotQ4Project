using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchArea : MonoBehaviour
{
    [SerializeField] Areas areaManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Switch(GameObject area) {
        areaManager.Switch(area);
    }
}
