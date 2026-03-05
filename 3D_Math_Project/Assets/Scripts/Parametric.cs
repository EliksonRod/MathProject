using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Parametric : MonoBehaviour
{
    [SerializeField]
    GameObject pointObject;

    int resolution = 10;

    public float coeffA = 1f;
    public float coeffB = 2f;

    public float exponentA = 1f;
    public float exponentB = 1f;

    public bool DrawGraph = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DrawGraphFunction();
    }

    void DrawGraphFunction()
    {
        if (!DrawGraph) return;

        var scale = Vector3.one / resolution;
        float t = Time.time;

        //
        float x = coeffA * Mathf.Sin(Mathf.Pow(t, exponentA));
        float y = coeffB * Mathf.Cos(Mathf.Pow(t, exponentB));
        GameObject graph = Instantiate(pointObject, new Vector3(x, y, 0), Quaternion.identity, transform);

        /**
         * 
         * do another parametric curve!!
         *
         **/

        //scales your graph points down according to resolution
        graph.transform.localScale = scale;
    }
}
