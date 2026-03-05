using UnityEngine;

public class RectToPoint : MonoBehaviour
{
    Vector3 Point;
    [SerializeField] GameObject rectPrefab;

    [Header("Shape Settings")]
    [SerializeField] float RectLength = 1f;
    [SerializeField] float RectWidth = 1f;

    GameObject Rectangle;
    SpriteRenderer SpriteRenderer;

    void Awake()
    {
        //instantiate both circles in the scene
        Rectangle = Instantiate(rectPrefab);

        SpriteRenderer = Rectangle.GetComponent<SpriteRenderer>(); //get the sprite renderer component of circle1 to change its color later on

        Rectangle.transform.localScale = new Vector3(RectLength, RectWidth, 1); //scale the rectangle according to its length and width
    }

    // Update is called once per frame
    void Update()
    {
        //one of the circles will follow your mouse
        Vector3 pos = Input.mousePosition;

        Point = Camera.main.ScreenToWorldPoint(pos);
        Point = new Vector3(Point.x, Point.y, 10); //set the z value of the point to 0 so that it is on the same plane as the circle
        Rectangle.transform.position = new Vector3(0, 0, Point.z);

        //run the collision detection function
        CheckCollision();
    }

    void CheckCollision()
    {
        float RectHalfLength = RectLength / 2;
        float RectHalfWidth = RectWidth / 2;

        float leftEdge = Rectangle.transform.position.x - RectHalfLength;
        float rightEdge = Rectangle.transform.position.x + RectHalfLength;
        float topEdge = Rectangle.transform.position.y + RectHalfWidth;
        float bottomEdge = Rectangle.transform.position.y - RectHalfWidth;

        //do this part in class
        if (Point.x <= rightEdge && Point.x >= leftEdge && Point.y <= topEdge && Point.y >= bottomEdge)
        {
            SpriteRenderer.color = Color.green; //collision detected, change color

        }
        else
        {
            SpriteRenderer.color = Color.white; // no collision
        }
    }
}
