using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    public float fadeOutTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Graphic g = GetComponent<Graphic>();
        Color c = g.color;
        float deltaTime = Time.deltaTime;
        
        if (c.a > 0 && fadeOutTime > 0)
        {
            float step = fadeOutTime / deltaTime;

            float decrement = c.a / step;

            if (decrement > c.a)
                c.a = 0;
            else
                c.a -= decrement;

            g.color = c;
        }
        fadeOutTime -= deltaTime;
    }
}
