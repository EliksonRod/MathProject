using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SwitchGraph : MonoBehaviour
{
    [SerializeField]
    Transform pointObject;

    [SerializeField, Range(-200, 200)]
    float x = 0.5f;
    [SerializeField, Range(-100, 100)]
    float coeff = 1f;
    [SerializeField, Range(-100, 100)]
    float exponent = 1f;

    [SerializeField] bool UseTime = false;
    float y;
    [SerializeField, Range(10, 100)]
    int resolution = 10;

    public GraphFunction function;

    float startTime;
    float elaspedTime;
    Transform[] points;
    Transform Point;
    List<GameObject> pointObjects = new List<GameObject>();
    float px;
    Vector3 scale;
    bool ResetTime = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       CreateGraph();
        startTime = Time.time;
    }

    void Update()
    {
        elaspedTime = Time.time - startTime;
        UpdateGraph();

        if (ResetTime)
        {
            ResetTime = false;
            ResetGameTime();
        }
        else
        {
            ResetTime = true;
        }
    }

    void CreateGraph()
    {
        px = 2f / resolution;
        points = new Transform[resolution];
        scale = Vector3.one * px;

        for (int i = 0; i < points.Length; i++)
        {
            float newX = (i + x) * px - 1f;
            float newY = coeff * (newX * newX);
            Point = Instantiate(pointObject, new Vector3(newX, newY, 0), Quaternion.identity, transform);
            Point.localScale = scale;

            pointObjects.Add(Point.gameObject);
            //CancelInvoke("CreateGraph");
        }
    }

    void ChooseGraphFunction(float newX)
    {
        switch (function)
        {
            case GraphFunction.Linear:
                y = newX;
                return;
            case GraphFunction.AdjustableExponent:
                y = Mathf.Pow(newX, exponent);
                break;
            case GraphFunction.Exponential:
                y = Mathf.Pow(coeff, newX);
                break;
            case GraphFunction.Quadratic:
                exponent = 2f;
                y = coeff *(Mathf.Pow(newX, exponent));
                break;
            case GraphFunction.Cubic:
                exponent = 3f;
                y = coeff * (Mathf.Pow(newX, exponent));
                break;
            case GraphFunction.SquareRoot:
                y = coeff * (Mathf.Sqrt(newX));
                break;
            case GraphFunction.CubeRoot:
                exponent = 1f/3f;
                y = coeff * (Mathf.Pow(newX, exponent));
                break;
            case GraphFunction.Step:
                y = coeff * (newX < 0f ? 0f : 1f);
                break;
            case GraphFunction.AbsoluteValue:
                y = coeff * (Mathf.Abs(newX));
                break;
            case GraphFunction.Sine:
                y = coeff * (Mathf.Sin(newX));
                break;
            case GraphFunction.Ripple:
                y = coeff * (Mathf.Sin(10f * newX) / (10f * newX));
                break;
                default:
                    y = 0f;
                break;
        }
    }

    void UpdateGraph()
    {
        for (int i = 0;i < pointObjects.Count;i++) 
        {
            float newX;
            if (!UseTime)
                newX = (i + x) * px - 1f;
            else
                newX = elaspedTime + (i + x) * px - 1f;

            ChooseGraphFunction(newX);
            pointObjects[i].transform.localPosition = new Vector3(newX, y, 0);
        }
    }


    public enum GraphFunction 
    { 
        Linear,
        Quadratic,
        Cubic,
        Exponential, 
        SquareRoot,
        CubeRoot,
        Step,
        AbsoluteValue,
        Sine, 
        Ripple,
        AdjustableExponent
    }

    void ResetGameTime()
    {
        elaspedTime = 0f;
    }
}


