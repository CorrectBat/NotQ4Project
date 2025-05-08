using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryArea : MonoBehaviour
{
    Queue<Duck> ducks;
    // Start is called before the first frame update
    void Start()
    {
        ducks = new Queue<Duck>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDuck(Duck duck) {
        ducks.Enqueue(duck);
    }
}
