using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;
using Color = UnityEngine.Color;    

public class HSV_Color_Changer : MonoBehaviour
{
    Vector3 Point;

    public float value = 0.7f;
    //Color fromHSV = Color.HSVToRGB(hue, saturation, value);

    Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //one of the circles will follow your mouse
        Vector3 pos = Input.mousePosition;

        Point = Camera.main.ScreenToWorldPoint(pos);
        float r = Mathf.Abs(Mathf.Sqrt(Point.x * Point.x + Point.y * Point.y)); //calculate the distance from the point to the origin (0, 0)
        float theta = Mathf.Abs(Mathf.Atan2(Point.y, Point.x)); //calculate the angle from the point to the origin (0, 0) in radians

        cam.backgroundColor = Color.HSVToRGB(theta, r, value);

    }
}
