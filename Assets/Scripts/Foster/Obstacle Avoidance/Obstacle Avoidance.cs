using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : Foster.Steering_Behaviours.Steering_Behaviours.ISteeringBehaviour
{
    Transform _origin;
    LayerMask _mask;
    float _radius;
    float _angle;

    Collider[] _obs;
    public ObstacleAvoidance(Transform origin, LayerMask mask, int maxObs , float angle,float radius)
    {
        _origin = origin;
        _radius = radius;
        _mask = mask;
        _obs = new Collider[maxObs];
        _angle = angle;
    }

    public Vector3 GetDir()
    {

        int countObs = Physics.OverlapSphereNonAlloc(_origin.position, _radius, _obs, _mask);
        Vector3 dirToAvoid = Vector3.zero;
        int detectedObs = 0;
        for (int i = 0; i< countObs; i++)
        {
            Collider currObs = _obs[i];
            Vector3 closestPoint = currObs.ClosestPointOnBounds(_origin.position);
            Vector3 diffToPoint = closestPoint - _origin.position;
            float angleToObs = Vector3.Angle(_origin.forward, diffToPoint);
            if (angleToObs > _angle / 2) continue;
            float distance = diffToPoint.magnitude;
            detectedObs++;
            dirToAvoid += -(diffToPoint).normalized * (_radius - distance);
        }
        if(detectedObs !=0)
            dirToAvoid /= detectedObs;


        return dirToAvoid.normalized;
    }
}
