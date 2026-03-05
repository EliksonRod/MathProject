using UnityEngine;

public class CustomCollider : MonoBehaviour
{
    //circle prefab will be the base shape/sprite for both circles in our screen
    [SerializeField]
    GameObject circlePrefab;

    //our two circles, each will have their own radius
    GameObject circle1;
    GameObject circle2;
    public float radius1;
    public float radius2;

    float Distance;

    void Start()
    {
        //instantiate both circles in the scene
        circle1 = Instantiate(circlePrefab);
        circle2 = Instantiate(circlePrefab);

        //scale the circles according to their radius
        circle1.transform.localScale = Vector3.one * radius1 * 2;
        circle2.transform.localScale = Vector3.one * radius2 * 2;
    }

    // Update is called once per frame
    void Update()
    {
        //one of the circles will follow your mouse
        Vector3 pos = Input.mousePosition;
        pos.z = 4f;
        circle2.transform.position = Camera.main.ScreenToWorldPoint(pos);

        //run the collision detection function
        CheckCollision();
        Distance = Vector3.Distance(circle1.transform.position, circle2.transform.position);
    }

    void CheckCollision()
    {
        //do this part in class
        if (radius1 + radius2 >= Distance)
        {
            Debug.Log("Collision Detected");
            
        }
        else
        {
             Debug.Log("No Collision Detected");
        }

    }
}
