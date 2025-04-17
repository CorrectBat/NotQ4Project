using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    Dictionary<DuckColors, Color> color;
    // Start is called before the first frame update
    void Start()
    {
        color = new Dictionary<DuckColors, Color>();
        InstantiateColors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateColors() {
        color.Add(DuckColors.green, new Color(30, 188, 115, 255));
        color.Add(DuckColors.blue, new Color(48, 225, 185, 255));
        color.Add(DuckColors.yellow, new Color(249, 194, 43, 255));
        color.Add(DuckColors.orange, new Color(247, 150, 23, 255));
        color.Add(DuckColors.purple, new Color(168, 132, 243, 255));
        color.Add(DuckColors.pink, new Color(202, 107, 108, 255));
    }

    public Color GetColor(DuckColors duckColor) {
        return color[duckColor];
    }
}
