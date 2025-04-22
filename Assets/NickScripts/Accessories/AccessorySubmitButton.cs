using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessorySubmitButton : MonoBehaviour, Clickable
{
    [SerializeField] AccessoryArea area;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        if(area.HasDuck()) {
            area.Restart();
        }
    }

    public void OnRelease() {

    }
}
