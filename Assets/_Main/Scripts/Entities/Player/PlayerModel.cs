using _Main.Scripts.FSM_SO_VERSION;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main.Scripts.Entities.Player
{
    public class PlayerModel : EntityModel
    {

        [SerializeField] private StateData[] fsmStates;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float maxLife = 100;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] float groundCheckLength;


        private Player_View _view;
        private Player_Controller _controller;
        private HealthController _healthController;
        bool _isGrounded;

        Rigidbody _rigidbody;
        Transform _transform;

        public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }
        public Player_View View { get => _view; set => _view = value; }

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _view = GetComponent<Player_View>();
            _controller = GetComponent<Player_Controller>();
            _healthController = new HealthController(maxLife);
            _healthController.OnDie += Die;
        }

        public override EntityModel GetModel() => this;

        public void Jump()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(5 * Vector3.up, ForceMode.Impulse);
        }

        public bool CheckGround()
        {
            _isGrounded = Physics.CheckSphere(transform.position, groundCheckLength, groundMask);
            View.PlayerGroundedAnimation(_isGrounded);
            View.PlayerFallingAnimation(!_isGrounded);
            //if (_isGrounded)
            //{
            //    //View.PlayerGroundedAnimation(true);
            //    View.PlayerJumpAnimation(false);
            //    //View.PlayerFallingAnimation(false);
            //}
            //else
            //{
            //    //View.PlayerGroundedAnimation(false);
            //    //View.PlayerFallingAnimation(true);
            //}
            return _isGrounded;
        }

        public override void Move(Vector3 direction)
        {
            direction.y = 0;
            _view.PlayRunAnimation(true);
            _rigidbody.velocity = direction * (maxSpeed * Time.deltaTime);

            if (direction.magnitude != 0)
                LookDir(direction);

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

        public override void Die()
        {
            SceneManager.LoadScene("Game Over");
        }

        public override Vector3 GetFoward() => transform.forward;


        public override float GetSpeed() => _rigidbody.velocity.magnitude;


        public override void LookDir(Vector3 dir)
        {
            if (dir == Vector3.zero) return;
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * rotSpeed);
        }

        public override Rigidbody GetRigidbody() => _rigidbody;

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(transform.position, Vector3.down * groundCheckLength);
        }

    }
}