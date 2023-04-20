using UnityEngine;
using zzzNico.Entities;

namespace Foster.Steering_Behaviours.Steering_Behaviours
{
    public class Pursuit : ISteeringBehaviour
    {

        Transform _origin;
        EntityModel _target;
        float _time;
        public Pursuit(Transform origin, EntityModel target, float time)
        {
            _origin = origin;
            _target = target;
            _time = time;
        }
        public virtual Vector3 GetDir()
        {
            float distance = Vector3.Distance(_origin.position, _target.transform.position);

            Vector3 point = _target.transform.position + (_target.GetFoward * Mathf.Clamp(_target.GetSpeed * _time, 0, distance));
            return (point - _origin.position).normalized;
        }
    }
}
