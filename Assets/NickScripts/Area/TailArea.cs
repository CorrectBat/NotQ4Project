using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailArea : MonoBehaviour
{
    Queue<Duck> ducks;
    Duck currentDuck;
    GameObject currDuckObject;
    bool duckReady;
    LiquidDuck liquidDuck;
    [SerializeField] GameObject liquidDuckPrefab;
    [SerializeField] ColorManager colorManager;
    [SerializeField] AccessoryArea accessoryArea;
    [SerializeField] Piston piston;

    // Start is called before the first frame update
    void Start()
    {
        ducks = new Queue<Duck>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!duckReady && ducks.Count > 0) {
            InstatiateDuck();
        }
    }

    void InstatiateDuck() {
        currentDuck = ducks.Dequeue();
        currDuckObject = Instantiate(liquidDuckPrefab);
        currDuckObject.transform.parent = this.transform;
        currDuckObject.transform.localPosition = new Vector2(-7.36f, -2.6f);
        currDuckObject.GetComponent<SpriteRenderer>().color = colorManager.GetColor(currentDuck.GetColor());
        Debug.Log(colorManager.GetColor(currentDuck.GetColor()));
        liquidDuck = currDuckObject.GetComponent<LiquidDuck>();
        duckReady = true;
    }   

    public void AddDuck(Duck duck) {
        ducks.Enqueue(duck);
    }

    public GameObject GetDuckObject() {
        return currDuckObject;
    }

    public LiquidDuck GetLiquidDuck() {
        return liquidDuck;
    }

    public void SendDuck() {
        currentDuck.SetTail(liquidDuck.GetTailShape());
        accessoryArea.AddDuck(currentDuck);
        piston.Empty();
        duckReady = false;
        Destroy(currDuckObject);
    }
}
