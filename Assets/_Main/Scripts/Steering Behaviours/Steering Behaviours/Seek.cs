using UnityEngine;

namespace _Main.Scripts.Steering_Behaviours.Steering_Behaviours
{
    public class Seek : ISteeringBehaviour
    {

        Transform origin;
        Transform target;

        public Seek(Transform origin, Transform target)
        {
            this.origin = origin;
            this.target = target;
        }

        public Vector3 GetDir()
        {
            return (target.position - origin.position).normalized;
        }

    }
}
