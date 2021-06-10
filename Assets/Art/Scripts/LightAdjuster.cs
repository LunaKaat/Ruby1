using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAdjuster : MonoBehaviour
{
    public Light myLight;
    public bool changeRange = false;
    public float rangeSpeed = 1.0f;
    public float maxRange = 1.0f;

    public bool changeColors = false;
    public float colorSpeed = 1.0f;
    public Color startColor;
    public Color endColor;

    float startTime;
   
    void Start()
    {
        myLight = GetComponent<Light>();
        startTime = Time.time;
    }

   
    void Update()
    {

        if(changeRange)
        {
            myLight.range = Mathf.PingPong(Time.time * rangeSpeed, maxRange);
        }


        if(changeColors)
        {
            float t = (Mathf.Sin(Time.time - startTime * colorSpeed));
            myLight.color = Color.Lerp(startColor, endColor, t);
        }
    }
}
