using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMode : MonoBehaviour
{

    [SerializeField]
    float range;

    [SerializeField]
    float angle;

    [SerializeField]
    LayerMask layer;

    public bool FieldofView(Transform target)
    {
        Vector3 diff = transform.position - target.transform.position;
        float distance = diff.magnitude;
        if (distance > range) return false;
        float angleToTarget = Vector3.Angle(transform.position, diff.normalized);
        if (angleToTarget > angle/2) return false;
        if (Physics.Raycast(transform.position, diff, distance, layer))
        {
            return true;
        }
        return true; 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * range);
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawRay(transform.position, Quaternion.Euler( 0, angle / 2, 0) * transform.forward * range);
        Gizmos.DrawRay(transform.position, Quaternion.Euler( 0, -angle / 2, 0) * transform.forward * range);
    }
}
