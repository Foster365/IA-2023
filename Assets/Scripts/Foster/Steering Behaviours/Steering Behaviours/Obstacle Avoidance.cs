using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : ISteeringBehaviour
{

    Transform _entity;
    Transform _target;
    float _radius;
    LayerMask _mask;
    float _avoidWeight;

    public ObstacleAvoidance(Transform entity, Transform target, float radius, LayerMask mask, float avoidWeight)
    {

        _entity = entity;
        _target = target;
        _radius = radius;
        _mask = mask;
        _avoidWeight = avoidWeight;

    }

    public Vector3 GetDir()
    {
        Collider[] obstacles = Physics.OverlapSphere(_entity.transform.position, _radius, _mask);
        Transform obstacleSave = null;
        var obstaclesCount = obstacles.Length;

        for (int i = 0; i < obstaclesCount; i++)
        {
            var currentObs = obstacles[i].transform;
            if (obstacleSave == null) obstacleSave = currentObs;
            else if (Vector3.Distance(_entity.position, obstacleSave.position) > Vector3.Distance(_entity.position, currentObs.position))
                obstacleSave = currentObs;
        }

        Vector3 dirToTarget = (_target.position - _entity.position).normalized;

        //Si hay un obstaculo, le agregamos a nuestra direccion una direccion de esquive
        if (obstacleSave != null)
        {
            Vector3 dirObsToNpc = (_entity.position - obstacleSave.position).normalized * _avoidWeight;
            dirToTarget += dirObsToNpc;
        }
        //retornamos la direccion final
        return dirToTarget.normalized;
    }
}
