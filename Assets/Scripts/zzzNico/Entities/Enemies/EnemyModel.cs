using System;
using System.Collections.Generic;
using UnityEngine;
using zzzNico.Entities.Player;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies
{
    public class EnemyModel : EntityModel
    {
        [SerializeField] private StateData[] fsmStates;
        [SerializeField] private float maxLife;
        [SerializeField] private PlayerModel playerModel;

        [Header("Patrol")]
        [SerializeField] private Transform[] patrolPoints;
        [SerializeField] private float restPatrolTime;

        [SerializeField] private float sightRange;
        [SerializeField] private float movementSpeed;
        [SerializeField] private int damage;
        private bool _isMoving;

        
        ISteeringBehaviour _sBehaviour;

        
        private Rigidbody _rb;
        private HealthController _healthController;
        private Enemy_Controller _controller;
        private BhTree _bhTree;


        private void Awake()
        {

            _rb = GetComponent<Rigidbody>();
            _sBehaviour=GetComponent<ISteeringBehaviour>();
            _healthController = new HealthController(maxLife);
            _healthController.OnDie += Die;
            _controller = GetComponent<Enemy_Controller>();
            
            _controller.InitializeState(fsmStates[0]);
            _bhTree = new BhTree(fsmStates, this);
            _bhTree.InitializeBhTree();
            
        }

        private void Update()
        {
            _bhTree.CheckChangeConditions(this);
        }

        public override void Move(Vector3 direction)
        {
            direction.y = 0;
            _rb.velocity = direction * movementSpeed;
            transform.forward = Vector3.Lerp(transform.forward, direction, 0.2f);
            // _enemyAnimation.RunAnimation();
            _isMoving=true;
        }

        public override void GetDamage(int damage)
        {
            _healthController.TakeDamage(damage);
        }

        public override void Heal(int healingPoint)
        {
            _healthController.Heal(damage);
        }

        public override Rigidbody GetRigidbody() => _rb;

        public override EntityModel GetModel() => this;

        public override void ChangeState(StateData exitState)
        {
            _controller.ExitCurrentState();
            
            //chequear si el exit del state realmente finalizo
            
            _controller.InitializeState(exitState);
        }

        public Transform[] GetPatrolPoints() => patrolPoints;
        public float GetPatrolTimer() => restPatrolTime;

        public override void Die()
        {
            Destroy(this.gameObject);
        }

        public PlayerModel GetTarget() => playerModel;
    }
}