﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundColor : MonoBehaviour {

    public PlatformController platControl;
    public Camera cam;
    public Color defaultColor;
    public Color32 redColor;
    public Color blueColor;
    public Color greenColor;
    public Color cyanColor;
    public Color magentaColor;
    public Color yellowColor;
    public Color whiteColor;

    public GameObject background;
    

    // Use this for initialization
    void Start () {
        background = GameObject.FindGameObjectWithTag("BG");
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    // Update is called once per frame
    void Update () {
        //cam.backgroundColor = redColor;
        if(platControl.greenState == true && !(platControl.blueState || platControl.redState))
        {
            cam.backgroundColor = greenColor;
            background.GetComponent<Renderer>().material.color = greenColor;
        }
        else if(platControl.redState == true && !(platControl.blueState || platControl.greenState))
        {
            cam.backgroundColor = redColor;
            background.GetComponent<Renderer>().material.color = redColor;
        }
        else if (platControl.blueState == true && !(platControl.redState || platControl.greenState))
        {
            cam.backgroundColor = blueColor;
            background.GetComponent<Renderer>().material.color = blueColor;
        }
        else if (platControl.cyanState == true && !(platControl.magentaState || platControl.yellowState))
        {
            cam.backgroundColor = cyanColor;
            background.GetComponent<Renderer>().material.color = cyanColor;
        }
        else if (platControl.magentaState == true && !(platControl.cyanState || platControl.yellowState))
        {
            cam.backgroundColor = magentaColor;
            background.GetComponent<Renderer>().material.color = magentaColor;
        }
        else if (platControl.yellowState == true && !(platControl.cyanState || platControl.magentaState))
        {
            cam.backgroundColor = yellowColor;
            background.GetComponent<Renderer>().material.color = yellowColor;
        }
        else if (platControl.yellowState && platControl.cyanState && platControl.magentaState)
        {
            cam.backgroundColor = whiteColor;
            background.GetComponent<Renderer>().material.color = whiteColor;
        }
        else
        {
            cam.backgroundColor = defaultColor;
            background.GetComponent<Renderer>().material.color = defaultColor;
        }
    }


}

