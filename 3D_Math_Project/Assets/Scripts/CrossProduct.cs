using UnityEngine;

public class CrossProductExample : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Vector3 laserStart = transform.position;
        Vector3 laserDir = transform.forward;

        if (Physics.Raycast(laserStart, laserDir, out RaycastHit hitInfo))
        {
            Vector3 hitPos = hitInfo.point;
            Vector3 up = hitInfo.normal;
            Vector3 right = Vector3.Cross(up, laserDir);
            Vector3 forward = Vector3.Cross(right, up);

            Vector3 NormalOpposite = -hitInfo.normal;

            Vector3 Reflect = Vector3.Cross(NormalOpposite, hitPos);

            //Start laser
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(laserStart, hitPos);
            //Gizmos.DrawRay(hitPos, -laserStart);

            //Opposite normal
            Gizmos.color = Color.green;
            Gizmos.DrawRay(hitPos, up);
            Gizmos.DrawRay(hitPos, NormalOpposite);

            //Reflected vector
            Gizmos.color = Color.red;
            Gizmos.DrawRay(hitPos, Reflect);
            //Gizmos.DrawRay(hitPos, Reflect);

            //draw "right" basis
            //Gizmos.color = Color.red;
            //Gizmos.DrawRay(hitPos, right);

            //draw "forward" basis
            //Gizmos.color = Color.cyan;
            //Gizmos.DrawRay(hitPos, forward);

        }
        else
        {
            //laser when it doesn't hit
            Gizmos.color = Color.white;
            Gizmos.DrawRay(laserStart, laserDir);
        }

    }
}


