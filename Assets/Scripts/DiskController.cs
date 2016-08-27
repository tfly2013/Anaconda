﻿using UnityEngine;
using System.Collections;

public class DiskController : MonoBehaviour {

    public int score;
    public float scale;
    public Color color;

    private Color[] colors = { Color.red, Color.yellow, Color.blue, Color.green, Color.black, Color.white, Color.cyan, Color.magenta};

    void Start () {
        var rvalue = Random.value;
        if (rvalue > 0.93)
        {
            score = 1000;
            scale = 1.5f;
        }            
        else if (rvalue > 0.8)
        {
            score = 500;
            scale = 1.3f;
        }            
        else if (rvalue > 0.6)
        {
            score = 200;
            scale = 1.1f;
        }
        else if (rvalue > 0.3)
        {
            score = 100;
            scale = 1;
        }
        else
        {
            score = 50;
            scale = 0.8f;
        }
        transform.localScale = new Vector3(scale, scale, scale);
        color = colors[(int)Random.Range(0, colors.Length - 1)];
        color.a = 0.7f;
        GetComponent<MeshRenderer>().material.color = color;
    }
}
