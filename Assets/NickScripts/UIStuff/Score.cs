using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] ScoreUI[] scoreUI;
    
    float[] scores;

    // Start is called before the first frame update
    void Start()
    {
        scores = new float[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScore() {
        for(int i=0; i<4; i++) {
            scoreUI[i].transform.GetChild(0).GetComponent<Text>().text = scores[i].ToString();
            scoreUI[i].SetUp();
        }
    }

    public void TakeDownScore() {
        for(int i=0; i<4; i++) {
            scoreUI[i].SetDown();
        }
    }

    public void calcScore(Order order, Duck duck) {
        /*if(order.color == duck.GetColor()) {
            scores[1] = duck.GetColorScore();
        } else {
            scores[1] = 0;
        }
        
        if(order.shape == duck.GetTailShape()) {
            scores[2] = duck.GetTailScore();
        } else {
            scores[2] = 0;
        }

        scores[3] = 1;

        List<ItemNames> itemReq = order.itemReq;
        List<ItemNames> duckItems = order.itemReq;

        foreach(ItemNames item in itemReq) {
            if(!(duckItems.Contains(item))) {
                scores[3] -= ((float)1 / itemReq.Count);
            }
        }

        foreach(ItemNames item in duckItems) {
            if(!itemReq.Contains(item)) {
                scores[3] -= ((float)1 / itemReq.Count);
            }
        }

        scores[3] = Math.Max(0, scores[3]);
        */
    }
}
