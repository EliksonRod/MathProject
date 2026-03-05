using UnityEngine;

public class PointToCircle : MonoBehaviour
{
    [SerializeField] GameObject circlePrefab;
    
    [Header("Shape Settings")]
    Vector3 Point;
    [SerializeField] float CircleRadius;

    GameObject CircleObject;
    SpriteRenderer CircleSpriteRenderer;  
    void Awake()
    {
        CircleObject = Instantiate(circlePrefab);

        CircleSpriteRenderer = CircleObject.GetComponent<SpriteRenderer>();
       
        CircleObject.transform.localScale = Vector3.one * CircleRadius * 2;
    }

    // Update is called once per frame
    void Update()
    {
        //one of the circles will follow your mouse
        Vector3 pos = Input.mousePosition;
 
        Point = Camera.main.ScreenToWorldPoint(pos);
        Point = new Vector3(Point.x, Point.y, 10); //set the z value of the point to 0 so that it is on the same plane as the circle
        CircleObject.transform.position = new Vector3(0, 0, Point.z);

        //run the collision detection function
        CheckCollision();
    }

    void CheckCollision()
    {
        float DistanceFromPointToCircle = Vector3.Distance(Point, CircleObject.transform.position);

        //do this part in class
        if (DistanceFromPointToCircle <= CircleRadius)
        {
            CircleSpriteRenderer.color = Color.blue; //collsion detected, change color
        }
        else
        {
            CircleSpriteRenderer.color = Color.white; //no collision
        }
    }
}
