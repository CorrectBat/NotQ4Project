using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidDuck : MonoBehaviour
{
    private TailShapes tailShape;
    private bool hasTail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTailShape(TailShapes newTailShape) {
        tailShape = newTailShape;
        hasTail = true;
    }

    public TailShapes GetTailShape() {
        return tailShape;
    }

    public bool HasTail() {
        return hasTail;
    }
}
