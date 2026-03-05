using UnityEngine;

public class CircleToCircle : MonoBehaviour
{
    //circle prefab will be the base shape/sprite for both circles in our screen
    [SerializeField]
    GameObject circlePrefab;

    [Header("Shape Settings")]
    [SerializeField] float radius1;
    [SerializeField] float radius2;

    //our two circles, each will have their own radius
    GameObject circle1;
    GameObject circle2;
    SpriteRenderer circle1SpriteRenderer;
    void Awake()
    {
        //instantiate both circles in the scene
        circle1 = Instantiate(circlePrefab);
        circle2 = Instantiate(circlePrefab);

        circle1SpriteRenderer = circle1.GetComponent<SpriteRenderer>(); //get the sprite renderer component of circle1 to change its color later on

        //scale the circles according to their radius
        circle1.transform.localScale = Vector3.one * radius1 * 2;
        circle2.transform.localScale = Vector3.one * radius2 * 2;
    }

    // Update is called once per frame
    void Update()
    {
        //one of the circles will follow your mouse
        Vector3 pos = Input.mousePosition;

        circle2.transform.position = Camera.main.ScreenToWorldPoint(pos);
        circle2.transform.position = new Vector3(circle2.transform.position.x, circle2.transform.position.y, 10);
        circle1.transform.position = new Vector3(0, 0, circle2.transform.position.z);

        //run the collision detection function
        CheckCollision();
    }

    void CheckCollision()
    {
        float DistanceBetweenCircles = Vector3.Distance(circle1.transform.position, circle2.transform.position);

        //do this part in class
        if (DistanceBetweenCircles <= radius1 + radius2)
        {
            circle1SpriteRenderer.color = Color.red; //collision detected, change color

        }
        else
        {
            circle1SpriteRenderer.color = Color.white; //no collision
        }
    }
}