using Foster.Steering_Behaviours.Steering_Behaviours;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using zzzNico.Entities.Enemies.Data;
using zzzNico.Entities.Player;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies
{
    public class EnemyModel : EntityModel
    {
        [SerializeField] private EnemyData data;

        [SerializeField] private Transform[] patrolPoints;
        [SerializeField] private PlayerModel playerModel;
        EnemyView _enemyView;


        private float _attackCooldown;


        ISteeringBehaviour _sBehaviour;


        private Rigidbody _rb;
        private HealthController _healthController;
        private Enemy_Controller _controller;

        public Enemy_Controller Controller { get => _controller; set => _controller = value; }

        private void Awake()
        {

            _rb = GetComponent<Rigidbody>();
            _sBehaviour = GetComponent<ISteeringBehaviour>();
            _healthController = new HealthController(data.MaxLife);
            _enemyView = GetComponent<EnemyView>();

            _controller = GetComponent<Enemy_Controller>();
            _attackCooldown = data.CooldownToAttack;
        }

        public override void Move(Vector3 direction)
        {
            direction.y = 0;
            _rb.velocity = direction * data.MovementSpeed;
            transform.forward = Vector3.Lerp(transform.forward, direction, 0.2f);
            _enemyView.PlayRunAnimation(this);
        }

        public override void LookDir(Vector3 dir)
        {
            if (dir == Vector3.zero) return;
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * rotSpeed);
        }

        public override void GetDamage(int damage)
        {
            _healthController.TakeDamage(damage);
        }

        public override void Heal(int healingPoint)
        {
            _healthController.Heal(healingPoint);
        }

        public override Rigidbody GetRigidbody() => _rb;

        public override EntityModel GetModel() => this;


        public void Attack(Vector3 dir)
        {
            if (_attackCooldown > 0) return;

            //que dispare


        }

        public override bool IsDead()
        {
            return _healthController.CurrentHealth <= 0;
        }

        public bool LineOfSight(Transform target)
        {
            Vector3 diff = target.transform.position - transform.position;

            float distanceToTarget = diff.magnitude;
            if (distanceToTarget > data.SightRange) return false;
            float angleToTarget = Vector3.Angle(transform.position, diff.normalized);
            if (angleToTarget > data.TotalSightDegrees / 2) return false;

            if (Physics.Raycast(transform.position, diff.normalized, data.SightRange, data.TargetLayer))
            {
                isAllert = true;
                isSeeingTarget = true;
                return true;
            }
            else return false;
        }
        public PlayerModel GetTarget() => playerModel;
        public EnemyData GetData() => data;
        public override StateData[] GetStates() => data.FsmStates;
        public Transform[] GetPatrolPoints() => patrolPoints;
    }
}