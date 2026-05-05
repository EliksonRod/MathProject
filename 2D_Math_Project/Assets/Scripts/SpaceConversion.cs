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
        Vector3 worldPoint = LocalSpaceToWorld(localSpacePoint);

        //drawing local point without conversion
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(localSpacePoint, 0.1f);

        //drawing local point after conversion (world point)
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(worldPoint, 0.1f);



        //World space to local space conversion
        Vector2 WorldSpaceToLocal(Vector3 WPoint)
        {
            Vector3 offset = WPoint - transform.position;
            float localX = Vector3.Dot(offset, transform.right);
            float localY = Vector3.Dot(offset, transform.up);
            Vector3 NewLocalSpace = new Vector3(localX, localY, 0);

            //return new local space
            return (Vector3)NewLocalSpace;

        }
        Vector2 localPoint = WorldSpaceToLocal(worldPoint);

        //drawing local point after conversion (world point)
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(localPoint, 0.1f);

        Debug.Log("Local Point: " + localSpacePoint + " World Point: " + worldPoint + " Converted Local Point: " + localPoint);

    }
}
