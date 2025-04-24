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
        if(tailArea.GetLiquidDuck().HasTail()) {
            tailArea.SendDuck();
        }
    }

    public void OnRelease() {

    }
}
