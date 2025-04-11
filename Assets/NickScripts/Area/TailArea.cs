using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailArea : MonoBehaviour
{
    Queue<Duck> ducks;
    Duck currentDuck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddDuck(Duck duck) {
        ducks.Enqueue(duck);
    }

    void PollDuck() {
        currentDuck = ducks.Dequeue();
    }
}
