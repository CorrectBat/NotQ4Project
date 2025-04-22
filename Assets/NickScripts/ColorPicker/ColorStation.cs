using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorStation : MonoBehaviour
{
    [SerializeField] TailArea tailArea;
    [SerializeField] Bucket bucket;
    [SerializeField] GameObject duckPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendDuck() {
        Instantiate(duckPrefab);
        Duck component = duckPrefab.GetComponent<Duck>();
        duckPrefab.SetActive(true);
        Debug.Log(component);
        component.SetColor(bucket.GetColor(), bucket.GetScore());
        tailArea.AddDuck(component);
        bucket.Empty();
    }
}
