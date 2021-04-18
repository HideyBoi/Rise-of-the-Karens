using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karen : MonoBehaviour
{
    //used to contain a meathod to enable an idividual gameobject for item collection now contains random sprite code

    public Sprite sprite0;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public SpriteRenderer image;
    public float RNG;

    void Awake()
    {
        
        RNG = Random.Range(0, 4);

        if(RNG == 0)
        {
            image.sprite = sprite0;
        }
        if(RNG == 1)
        {
            image.sprite = sprite1;
        }
        if(RNG == 2)
        {
            image.sprite = sprite2;
        }
        if(RNG == 3)
        {
            image.sprite = sprite3;
        }
    }
   
}
