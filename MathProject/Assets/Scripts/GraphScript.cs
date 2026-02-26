using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GraphScript : MonoBehaviour
{
    [SerializeField]
    Transform pointObject;

    [SerializeField, Range(-100, 100)]
    float x = 0.5f;
    [SerializeField, Range(-100, 100)]
    float coefficient;
    [SerializeField, Range(-20, 20)]
    float exponent = 2;
    [SerializeField, Range(10, 100)]
    int resolution = 10;

    Transform[] points;
    Transform Point;
    List<GameObject> pointObjects = new List<GameObject>();
    float px;
    Vector3 scale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       CreateGraph();
    }

    void Update()
    {
        UpdateGraph();
    }


    void CreateGraph()
    {
        px = 2f / resolution;
        points = new Transform[resolution];
        scale = Vector3.one * px;

        for (int i = 0; i < points.Length; i++)
        {
            float newX = (i + x) * px - 1f;
            float y = coefficient * Mathf.Pow(newX, exponent);
            Point = Instantiate(pointObject, new Vector3(newX, y, 0), Quaternion.identity, transform);
            Point.localScale = scale;

            pointObjects.Add(Point.gameObject);
            //CancelInvoke("CreateGraph");
        }
    }


    void UpdateGraph()
    {
        for (int i = 0;i < pointObjects.Count;i++) 
        {
            float newX = (i + x) * px - 1f;
            float y = coefficient * Mathf.Pow(newX, exponent);
            pointObjects[i].transform.localPosition = new Vector3(newX, y, 0);
        }
    }
}


