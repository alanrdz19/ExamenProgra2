using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{

    public float speed;
    public Material material;

    private void Start()
    {
        
    }

    private void Update()
    {
        material.mainTextureOffset += new Vector2(0, 0.1f) * -speed * Time.deltaTime;
    }
}
