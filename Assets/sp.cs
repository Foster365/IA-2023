using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sp : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position, 1f);
    }
}
