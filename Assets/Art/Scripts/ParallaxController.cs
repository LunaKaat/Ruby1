using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField]
    List<ParallaxLayers> parallaxLayersList = new List<ParallaxLayers>();
    public ParallaxCamera ParallaxCamera;
    //public ParallaxLayers ParallaxLayers;

    private void Start()
    {
        if (ParallaxCamera == null)
            ParallaxCamera = Camera.main.GetComponent<ParallaxCamera>();

        if (ParallaxCamera != null)
        {
            ParallaxCamera.onCameraTranslateX += MoveX;
            ParallaxCamera.onCameraTranslateY += MoveY;
        }

        GetLayers();

    }

    private void MoveX(float delta)
    {

    }
   
    private void MoveY(float delta)
    {

    }



    private void GetLayers()
    {
        parallaxLayersList.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            ParallaxLayers layer = transform.GetChild(i).GetComponent<ParallaxLayers>();
            if (layer != null)
                parallaxLayersList.Add(layer);
        }
    }

}
