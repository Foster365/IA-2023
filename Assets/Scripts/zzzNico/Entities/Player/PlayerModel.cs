using System;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Player
{
    public class PlayerModel : EntityModel
    {

        [SerializeField] private StateData[] fsmStates;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float maxLife = 100;
        [SerializeField] private LayerMask groundMask;


        private Player_View _view;
        private Player_Controller _controller;
        private HealthController _healthController;
        private bool _isGrounded;

        Rigidbody _rigidbody;
        Transform _transform;

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _view = GetComponent<Player_View>();
            _controller = GetComponent<Player_Controller>();
            _healthController = new HealthController(maxLife);
        }

        public override EntityModel GetModel() => this;

        public void Jump()
        {
            _rigidbody.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }

        public bool CheckGround() => Physics.Raycast(transform.position, Vector3.down, 1f, groundMask);

        public override void Move(Vector3 direction)
        {
            direction.y = 0;
            _rigidbody.velocity = direction * maxSpeed;
            transform.forward = Vector3.Lerp(transform.forward, direction, 0.2f);
            _view.PlayRunAnimation(this);
        }

        public override void GetDamage(int damage)
        {
            _healthController.TakeDamage(damage);
        }

        public override void Heal(int healingPoint)
        {
            _healthController.Heal(healingPoint);
        }

        public override StateData[] GetStates()
        {
            return fsmStates;
        }

        public override bool IsDead()
        {
            return _healthController.CurrentHealth <= 0;
        }

        public override void LookDir(Vector3 dir)
        {
            if (dir == Vector3.zero) return;
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * rotSpeed);
        }

        public override Rigidbody GetRigidbody() => _rigidbody;

    }
}