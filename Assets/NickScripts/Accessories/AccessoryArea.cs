using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryArea : MonoBehaviour
{
    Queue<Duck> ducks;
    AccessoryDuck currPrefab;
    Duck currDuck;
    bool duckActive;
    [SerializeField] AccessoryItemList items;
    [SerializeField] GameObject duckPrefab;
    // Start is called before the first frame update
    void Start()
    {
        ducks = new Queue<Duck>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!duckActive && ducks.Count > 0) {
            Restart();
            currDuck = ducks.Dequeue();
            duckActive = true;
            var temp = Instantiate(duckPrefab);
            temp.transform.parent = this.transform;
            currPrefab = temp.GetComponent<AccessoryDuck>();
        }
    }

    public void AddDuck(Duck duck) {
        ducks.Enqueue(duck);
    }

    public bool HasDuck() {
        return duckActive;
    }

    public void Restart() {
        items.Restart();
        if(duckActive) {
            AssignDuckItems();
            duckActive = false;
            Destroy(currPrefab.gameObject);
        }
    }

    public void AssignDuckItems() {
        currDuck.AddItems(currPrefab.GetItems());
    }
}
