﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingBackground : MonoBehaviour

{

    //to apply on the plane

    Material mat;
    public float xVelocity, yVelocity;
    Vector2 offset;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset += offset * Time.deltaTime;
    }
}
