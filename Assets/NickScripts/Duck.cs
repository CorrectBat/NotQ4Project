using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    private DuckColors color;
    private List<ItemNames> items;
    private TailShapes tailShape;
    private DuckStage duckStage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        duckStage = DuckStage.tail;   
    }

    public void SetColor(DuckColors newColor) {
        color = newColor;
    }

    public void AddItem(ItemNames item) {
        items.Add(item);
    }

    public void SetTail(TailShapes tail) {
        tailShape = tail;
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
