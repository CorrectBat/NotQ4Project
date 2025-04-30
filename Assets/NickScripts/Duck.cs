using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    private DuckColors color;
    private float colorScore;
    private List<ItemNames> items;
    private float itemScore;
    private TailShapes tailShape;
    private float tailScore;
    private DuckStage duckStage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        duckStage = DuckStage.tail;   
    }

    public DuckColors GetColor() {
        return color;
    }
    public void SetColor(DuckColors newColor, float score) {
        color = newColor;
        Debug.Log(newColor);
        tailScore = score;
        Debug.Log(score);
    }

    public void AddItems(List<ItemNames> items) {
        this.items = items;
    }

    public void SetTail(TailShapes tail) {
        tailShape = tail;
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
