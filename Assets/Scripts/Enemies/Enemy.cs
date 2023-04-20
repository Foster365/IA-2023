using System.Collections.Generic;
using Foster.Steering_Behaviours.Steering_Behaviours;
using Player;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {

        public float life;
    
        //Waypoint System (Patrol) variables
        public List<Transform> Waypoints;
        public float distance;
        int _nextwp=0;
        int _indexModifier = 1;
        //

        // Variables LOS
        [SerializeField]
        float sbR;

        [SerializeField]
        float angle;
    
        [SerializeField]
        LayerMask layer;
        //

        public float sightRange;
        public float movementSpeed;
        public int damage;
        bool isMoving;

        public bool IsMoving{get=>isMoving;set=>isMoving=false;}
        Rigidbody _rb;
        GameObject _gameObject;
        public PlayerMC _player;
        ISteeringBehaviour _sBehaviour;

        EnemyAnimation _enemyAnimation;

        public ParticleSystem muzzleFlash;
    
        private void Awake()
        {

            _rb = GetComponent<Rigidbody>();
            _gameObject=GetComponent<GameObject>();
            _enemyAnimation= GetComponent<EnemyAnimation>();
            _sBehaviour=GetComponent<ISteeringBehaviour>();

        }
    
        public void Move(Vector3 dir)
        {
        
            dir.y = 0;
            _rb.velocity = dir * movementSpeed;
            transform.forward = Vector3.Lerp(transform.forward, dir, 0.2f);
            // _enemyAnimation.RunAnimation();
            isMoving=true;

        }
    
        public Vector3 GoToWaypoint()
        {
        
            var waypoint = Waypoints[_nextwp];
            var waypointPosition = waypoint.position;
            waypointPosition.y = transform.position.y;
            Vector3 dir = waypointPosition - transform.position;
            if (dir.magnitude < distance)
            {
                if (_nextwp + _indexModifier >= Waypoints.Count || _nextwp + _indexModifier < 0)
                    _indexModifier *= -1;
                _nextwp += _indexModifier;
            }
            Move(dir.normalized);
            return dir;

        }

        public bool LineOfSight(Transform target)
        {

            Vector3 diff = transform.position - target.transform.position;
            float distance = diff.magnitude;
            if (distance > sbR) return false;
            float angleToTarget = Vector3.Angle(transform.position, diff.normalized);
            if (angleToTarget > angle/2) return false;
            if (Physics.Raycast(transform.position, diff, distance, layer)) return true;

            return true;
        
        }
    
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, transform.forward * sightRange);
            Gizmos.DrawWireSphere(transform.position, sightRange);
            Gizmos.DrawRay(transform.position, Quaternion.Euler( 0, angle / 2, 0) * transform.forward * sightRange);
            Gizmos.DrawRay(transform.position, Quaternion.Euler( 0, -angle / 2, 0) * transform.forward * sightRange);
        }
        public void Attack()
        {
            // bool isShoot=false;
            // if(Physics.Raycast(transform.position, transform.forward, bulletDistance, layerMask))
            // {
            //     isShoot=true;
            // }         
            RaycastHit hit;
            if (Physics.Raycast (transform.position, transform.forward, out hit))
            {
                if(hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Shooting player");
                    muzzleFlash.Play();
                    _player.GetDamage(100);
                    //  hit.collider.gameObject.GetComponent<PlayerHealth>().health -= 5f;
                }
            }
        }
    
        public void GetDamage(int damage)
        {
            life-=damage;
        
            if(life<=0)
                Destroy(this);
        }
    }
}
