using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Parametric : MonoBehaviour
{
    [SerializeField]
    GameObject pointObject;

    public int resolution = 10;
    public bool DrawGraph = true;
    public bool UseZ = false;

    public float r0 = 1f;
    public float r1 = 1f;

    public float d0 = 45f;
    public float d1 = 45f;

    // Update is called once per frame
    void Update()
    {
        DrawGraphFunction();
    }

    void DrawGraphFunction()
    {
        if (!DrawGraph) return;

        var scale = Vector3.one / resolution;
        GameObject graph;
        float t = Time.time;

        float x = (r0 - r1) * Mathf.Cos(t) + d0 * Mathf.Cos(((r0 - r1) / r1) * t);
        float y = (r0 - r1) * Mathf.Sin(t) - d0 * Mathf.Sin(((r0 - r1) / r1) * t);
        float z = (r0 - r1) * Mathf.Sin(t) - d0 * Mathf.Sin(((r0 - r1) / r1) * t);

        float a = (r0 + r1) * Mathf.Cos(t) - d1 * Mathf.Cos(((r0 + r1) / r1) * t);
        float b = (r0 + r1) * Mathf.Sin(t) - d1 * Mathf.Sin(((r0 + r1) / r1) * t);
        float c = (r0 - r1) * Mathf.Sin(t) + d1 * Mathf.Sin(((r0 - r1) / r1) * t);

        //Instantiate points  
        if (UseZ)
        {
            graph = Instantiate(pointObject, new Vector3(x, y, z), Quaternion.identity, transform);
            graph = Instantiate(pointObject, new Vector3(a, b, c), Quaternion.identity, transform);
        }
        else
        {
            graph = Instantiate(pointObject, new Vector3(x, y, 0), Quaternion.identity, transform);
            graph = Instantiate(pointObject, new Vector3(a, b, 0), Quaternion.identity, transform);
        }
            //scales your graph points down according to resolution
            graph.transform.localScale = scale;
    }
}
