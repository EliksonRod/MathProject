using UnityEngine;
using UnityEngine.UI;

public class Vectors : MonoBehaviour
{
    [SerializeField] GameObject Cube;
    [SerializeField] GameObject MirrorPlayer;
    [SerializeField] GameObject Hazard;

    //Get SpriteRenderer of the cube
    [SerializeField] SpriteRenderer sr;

    [SerializeField] float ScalerValue = 2f;
    void Start()
    {
        sr = Cube.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
    }

    void OnDrawGizmos()
    {
        //does not run/draw in the game
        /*
        Vector2 target = transform.position;
        Vector2 dirToTarget = target.normalized;
        Gizmos.DrawLine(Vector2.zero, dirToTarget);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector2.zero, Vector2.right);

        float dot = Vector2.Dot(Vector2.right, dirToTarget);
        Debug.Log(dot);*/

         Vector3 target = Cube.transform.position;
         Vector3 dirToTarget = target.normalized;
        //Gizmos.DrawLine(Vector3.right, dirToTarget);
        Gizmos.DrawLine(Vector3.zero, dirToTarget);


        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(Vector3.zero, Vector3.right);

        float dot = Vector3.Dot(Vector3.right, dirToTarget);
        //Debug.Log(dot);

        if (dot < 0)
        {
            //Debug.Log("Target is to the left");
        }
        else if (dot > 0)
        {
            //Debug.Log("Target is to the right");
        }
        else if (dot == 0)
        {
            //Debug.Log("Target is straight ahead or behind");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = Cube.transform.position;
        Vector3 dirToTarget = target.normalized;

        //Adds two vectors together and moves hazard to the result
        Vector3 VectorAddition = Vector3.right + dirToTarget;
        Debug.DrawLine(Vector3.zero, VectorAddition, Color.red);
        Hazard.transform.position = VectorAddition;

        //Scaler opertation, creating a mirror player that copys the movement of the player
        ScalerValue = -Vector3.Distance(Cube.transform.position, this.transform.position);
        Vector3 ScalerVector = dirToTarget * ScalerValue;
        Debug.DrawLine(Vector3.zero, ScalerVector, Color.blue);
        MirrorPlayer.transform.position = ScalerVector;

        //Dot product for determining location of player relative to the right vector from this object
        float dot = Vector3.Dot(Vector3.right, dirToTarget);
        //Debug.Log(dot);

        if (dot < 0)
        {
            //Negative means they are pointing in opposite directions
            Debug.Log("Target is to the left");
            sr.color = Color.blue;
        }
        else if (dot > 0)
        {
            //A positive dot product means the vectors are pointing in the same direction
            Debug.Log("Target is to the right");
            sr.color = Color.red;
        }
        else if (dot == 0)
        {
            //Zero means they are perpendicular
            Debug.Log("Target is straight ahead or behind");
            sr.color = Color.green;
        }
    }
}
