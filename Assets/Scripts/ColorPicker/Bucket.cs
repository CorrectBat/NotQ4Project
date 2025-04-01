using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    private float filledAmount = 0;
    private float neededAmount;
    [SerializeField] float fillFactor;
    [SerializeField] Pourer pourer;
    private Transform liquid;
    private Transform needLine;

    // Start is called before the first frame update
    void Start()
    {
        liquid = transform.GetChild(0).transform;
        needLine = transform.GetChild(1).transform;
        liquid.transform.localScale = new Vector3(1, 0, 1);
        liquid.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(pourer.IsPouring() && filledAmount <=1) {
            liquid.transform.localScale = new Vector3(1, filledAmount*2, 1);
        }

        if(neededAmount < filledAmount) {
            Debug.Log("Overfilled!");
        }
    }
    public void setNeededAmount(float amount) {
        neededAmount = amount;
        needLine.localPosition = new Vector3(0, amount-0.5f, 0);
    }

    public void fill(float amount) {
        filledAmount += amount*fillFactor;
    }

    public void SetColor(Color color) {
        liquid.GetComponent<SpriteRenderer>().color = color;
    }
}
