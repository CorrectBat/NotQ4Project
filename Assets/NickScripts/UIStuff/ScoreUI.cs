using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] float top;
    [SerializeField] float bottom;
    private bool isGoingUp;
    private bool isGoingDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGoingUp) {
            MoveUp();
        }

        if(isGoingDown) {
            MoveDown();
        }
    }

    void MoveUp() {
        transform.position = new Vector3(transform.position.x, transform.position.y+(20*Time.deltaTime), transform.position.x);
        if(transform.position.y >= top) {
            transform.position = new Vector3(transform.position.x, top, transform.position.z);
            isGoingUp = false;
        }
    }

    void MoveDown() {
        transform.position = new Vector3(transform.position.x, transform.position.y-(20*Time.deltaTime), transform.position.x);
        if(transform.position.y <= bottom) {
            transform.position = new Vector3(transform.position.x, top, transform.position.z);
            isGoingDown = false;
        }
    }

    public void SetUp() {
        isGoingUp = true;
    }

    public void SetDown() {
        isGoingDown = true;
    }
}
