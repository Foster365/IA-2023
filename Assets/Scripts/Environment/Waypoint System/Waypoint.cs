using UnityEngine;

namespace Environment.Waypoint_System
{
    public class Waypoint : MonoBehaviour
    {

        private void OnDrawGizmos()
        {

            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, 1);

        }


    }
}
