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
            Vector3 NormalOpp = -hitInfo.normal;
            Vector3 right = Vector3.Cross(up, laserDir);
            Vector3 forward = Vector3.Cross(right, up);

            //laser
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(laserStart, hitPos);

            //draw "up" basis, ie the normal
            Gizmos.color = Color.green;
            Gizmos.DrawRay(hitPos, NormalOpp);

            //draw "right" basis
            Gizmos.color = Color.red;
            Gizmos.DrawRay(hitPos, right);

            //draw "forward" basis
            Gizmos.color = Color.cyan;
            Gizmos.DrawRay(hitPos, forward);

        }
        else
        {
            //laser when it doesn't hit
            Gizmos.color = Color.white;
            Gizmos.DrawRay(laserStart, laserDir);
        }

    }
}


