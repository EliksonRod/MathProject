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
        Vector2 pos = Input.mousePosition;
        Point = Camera.main.ScreenToWorldPoint(pos);

        Debug.Log("Point: " + Point);
        float x = Point.x;
        float y = Point.y;

        float r = Mathf.Sqrt((x * x) + (y * y));

        r = Mathf.Clamp01(r / 10); 

        float theta = Mathf.Atan2(y, x) * Mathf.Deg2Rad;

        Debug.Log("Theta: " + theta + " R: " + r);


        cam.backgroundColor = Color.HSVToRGB(theta, r, 1);



    }
}
