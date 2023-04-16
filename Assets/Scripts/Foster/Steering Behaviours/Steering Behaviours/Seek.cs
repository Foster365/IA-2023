using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zzzNico.Entities.Enemies;
using zzzNico.Entities.Player;

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
