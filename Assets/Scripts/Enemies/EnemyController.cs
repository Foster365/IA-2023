using Finite_State_Machine;
using Finite_State_Machine.FSM_State.Enemy_States;
using Foster.Steering_Behaviours.Steering_Behaviours;
using UnityEngine;

namespace Enemies
{
    public class EnemyController : MonoBehaviour
    {

        //SBehaviours variables
        public Transform sbTarget;
        public Rigidbody sbRbTarget;
        public float sbTimePrediction;
        public float sbRange;
        public float sbRadius;
        public LayerMask sbLayerMask;
        public float avoidWeight;
        //

        //Line of sight variables
        public Transform target;
        //

        //FSM variables
        FSM<string> _fsm;
        public Rigidbody _rigidbody;
        //

        //Idle variables
        public float idleTimer;
        //

        //Patrol variables
        public float patrolCounter;
        //

        //Enemy Attack variables
        public float patrolDistance;
        public int bulletDistance;
        public LayerMask attackLayerMask;
        //
        public Enemy _enemy;
        public Transform _player;
        ISteeringBehaviour SBehaviour;
        private void Awake()
        {
        
            _enemy = GetComponent<Enemy>();
        

        }
        private void Start()
        {
        
            SBehaviour=new ObstacleAvoidance(_enemy.transform, sbTarget, sbRadius, sbLayerMask, avoidWeight);
        
            _fsm = new FSM<string>();

            IdleState<string> idleState = new IdleState<string>(_enemy, _player, _rigidbody, idleTimer, _fsm,"PatrolState", "SeekState");
            PatrolState<string> patrolState = new PatrolState<string>(_enemy, target, SBehaviour, patrolCounter, _fsm, "IdleState", "SeekState");
            SeekState<string> seekState = new SeekState<string>(_enemy,patrolDistance, bulletDistance, _player,  SBehaviour, _fsm, "PatrolState", "AttackState");
            AttackState<string> attackState =  new AttackState<string>(_enemy, target, attackLayerMask, bulletDistance, _fsm, "SeekState");

            idleState.AddTransition("PatrolState", patrolState);
            idleState.AddTransition("SeekState", seekState);

            patrolState.AddTransition("IdleState", idleState);
            patrolState.AddTransition("SeekState", seekState);
        
            seekState.AddTransition("PatrolState", patrolState);
            seekState.AddTransition("AttackState", attackState);

            attackState.AddTransition("SeekState", seekState);
            _fsm.SetInit(patrolState);

        }

        // Update is called once per frame
        void Update()
        {
        
            _fsm.OnUpdate();
        
        }
    
        public void ChangeSteering(ISteeringBehaviour sb)
        {
            SBehaviour = sb;
        }
    
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, sbRadius);
        }

    }
}
