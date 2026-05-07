
using UnityEngine;

public class CrossProductExample : MonoBehaviour
{
    public int maxBounces = 5;
    void OnDrawGizmos()
    {
        Vector3 laserStart = transform.position;
        Vector3 laserDir = transform.forward;

        if (Physics.Raycast(laserStart, laserDir, out RaycastHit hitInfo))
        {
            Vector3 hitPos = hitInfo.point;
            Vector3 hitNormal = hitInfo.normal.normalized;
            Vector3 NormalOpposite = -hitInfo.normal.normalized;
            //Vector3 continuedLaser

            float Reflect = Vector3.Dot(laserDir, hitNormal);
            Vector3 ReflectVector = laserDir - 2 * Reflect * hitNormal;

            Vector3 continuedLaser = hitPos + laserDir;


            //Start laser
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(laserStart, hitPos);
            //Gizmos.DrawRay(hitPos, continuedLaser);

            //Opposite normal
            Gizmos.color = Color.green;
            Gizmos.DrawRay(hitPos, hitNormal);
            //Gizmos.DrawRay(hitPos, NormalOpposite);

            //Reflected vector
            Gizmos.color = Color.red;
            Gizmos.DrawRay(hitPos, ReflectVector);
            //Gizmos.DrawRay(hitPos, Reflect);
        }
        else
        {
            //laser when it doesn't hit
            Gizmos.color = Color.white;
            Gizmos.DrawRay(laserStart, laserDir);
        }
    }
}


