using Foster.Steering_Behaviours.Steering_Behaviours;
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
        bool _isGrounded;

        Rigidbody _rigidbody;
        Transform _transform;

        public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }

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
            _view.ResetTriggerAnim("onJump");
            _rigidbody.velocity = Vector3.zero;
            //_rigidbody.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            _view.PlayerJumpAnimation();
        }

        public bool CheckGround()
        {
            return _isGrounded = Physics.Raycast(transform.position, -Vector3.up, 10f, groundMask) ? true : false;
        }

        public override void Move(Vector3 direction)
        {
            direction.y = 0;
            _rigidbody.velocity = direction * maxSpeed;
            if (direction.x != 0 || direction.z != 0)
                transform.forward = direction;
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

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(transform.position, -transform.up * .1f);
        }

    }
}