using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrone : MonoBehaviour
{

    //LOS Variables
    public float radiusLOS;
    public LayerMask mask;
    public float angle;
    bool inSight=false;
    
    //

    public float life;
    public float movementSpeed;
    public float attackDistance;
    public float followDistance;

    // public Transform enTarget;

    Rigidbody _rigidbody;
    public PlayerMC player;
    

    private void Awake()
    {
        _rigidbody=GetComponent<Rigidbody>();
    }
    private void Start()
    {
        
    }
    
    private void Update()
    {
        // NearestEnemyDirection();
    }

    public Vector3 FindPLayer()
    {
        Vector3 dir;
        return dir=player.transform.position - transform.position;
        // return GameObject.FindGameObjectWithTag("Player");
    }
    public void Move(Vector3 dir)
    {
        
        dir.y = 0;
        _rigidbody.velocity = dir * movementSpeed;
        transform.forward = Vector3.Lerp(transform.forward, dir, 0.2f);
        // isMoving=true;//Usar en el tree

    }
    public void FollowPlayer()
    {
        Debug.Log("Following");
        Move(FindPLayer());;
    }
    public bool LineOfSight()
    {
        
        Vector3 diff = transform.position - player.transform.position;
        float distance = diff.magnitude;
        if (distance > radiusLOS) return false;
        float angleToTarget = Vector3.Angle(transform.position, diff.normalized);
        if (angleToTarget > angle/2) return false;
        if (Physics.Raycast(transform.position, diff, distance, mask))
        {
            return true;
        }
        return true;
        
    }

    public void Dead()
    {
        Debug.Log("Dead");
        if(life<=0)
            Destroy(this);
    }
    
    public void Healing()
    {
        Debug.Log("Successfully healed");
        player.Healer(50);
    }

    public void PartialHealing()
    {
        Debug.Log("Partially successfull healed");
        player.Healer(10);
    }

    public void FailHeaing()
    {
        Debug.Log("Healing failed, sorry :(");
        player.GetDamage(10);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, transform.forward * radiusLOS);
        Gizmos.DrawWireSphere(transform.position, radiusLOS);
        Gizmos.DrawRay(transform.position, Quaternion.Euler( 0, angle / 2, 0) * transform.forward * radiusLOS);
        Gizmos.DrawRay(transform.position, Quaternion.Euler( 0, -angle / 2, 0) * transform.forward * radiusLOS);
    }

    // public void Attack()
    // {
    //     RaycastHit hit;
    //     if(Physics.Raycast(transform.position, transform.forward, out hit, mask))
    //     {
    //         Debug.Log("Attack");
    //     }
    // }
    
    // public Transform NearestEnemyDirection()
    // {
        
    //     Collider[] enemies = Physics.OverlapSphere(transform.position, radiusLOS);
    //     Transform enemySave = null;
    //     var enemiesCount = enemies.Length;

    //     for (int i = 0; i < enemiesCount; i++)
    //     {
    //         var currentEnemy = enemies[i].transform;
    //         if (enemySave == null) enemySave = currentEnemy;
    //         else if (Vector3.Distance(transform.position, enemySave.transform.position) > Vector3.Distance(transform.position, currentEnemy.position))
    //             enemySave = currentEnemy;
    //     }
    //     Debug.Log("ESave" + enemySave);
    //     return enemySave;

    // }

    public bool IsAlive()
    {
        Debug.Log("Is drone alive?");
        return life > 0;
    }

    public bool PlayerLowLife()
    {
        Debug.Log("Low life player?");

        return player.life < 30;
    }
    
}
