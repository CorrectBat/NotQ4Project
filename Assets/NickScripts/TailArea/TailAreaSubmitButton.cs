using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailAreaSubmitButton : MonoBehaviour, Clickable
{
    [SerializeField] TailArea tailArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        Debug.Log("hi1");
        if(tailArea.GetLiquidDuck().HasTail()) {
            Debug.Log("hi2");
            tailArea.SendDuck();
        }
    }

    public void OnRelease() {

    }
}
