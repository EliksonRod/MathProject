using UnityEngine;

public class SpaceConversion : MonoBehaviour
{
    public Vector2 localSpacePoint;
    
    void OnDrawGizmos()
    {
        //draw world space basis vectors
        Gizmos.color = Color.green;
        Gizmos.DrawRay(Vector2.zero, Vector2.up);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(Vector2.zero, Vector2.right);

        //draw local space basis vectors
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.up);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right);

        //local space to world space conversion
        Vector2 LocalSpaceToWorld(Vector2 Lpoint)
        {
            Vector2 offset = Lpoint.x * transform.right + Lpoint.y * transform.up;
            return (Vector2)transform.position + offset;
        }
        Vector2 worldPoint = LocalSpaceToWorld(localSpacePoint);

        //drawing local point without conversion
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(localSpacePoint, 0.1f);

        //drawing local point after conversion (world point)
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(worldPoint, 0.1f);



        //World space to local space conversion
        Vector2 WorldSpaceToLocal(Vector2 WPoint)
        {
            float dot = Vector2.Dot(localSpacePoint, WPoint);
            //Vector2 point = dot * transform.right + dot * transform.up;
            Vector2 point = dot * WPoint;


            Vector2 offset = -transform.right * WPoint.x - transform.up * WPoint.y;
            return (Vector2)transform.position + offset;
        }
        Vector2 localPoint = WorldSpaceToLocal(worldPoint);

        //drawing local point after conversion (world point)
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(localPoint, 0.1f);

        Debug.Log("Local Point: " + localSpacePoint + " World Point: " + worldPoint + " Converted Local Point: " + localPoint);




    }
}
