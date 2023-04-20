using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities
{
    public abstract class EntityModel : MonoBehaviour
    {

        public bool isIdle;
        public bool isPatrolling;
        public bool isSeeingTarget;
        public bool isChasing;
        public bool isAttacking;
        public bool isSearching;
        public bool isAllert;

        public bool isWalking;
        public bool isCrouched;
        public bool isDead;

        public Rigidbody _Rb { get; set; }

        public abstract void Move(Vector3 direction);

        public virtual void DoDamage(EntityModel affectedModel) { }

        public abstract void GetDamage(int damage);
        public abstract void Heal(int healingPoint);
        public abstract Rigidbody GetRigidbody();
        public abstract EntityModel GetModel();
        public abstract StateData[] GetStates();
        public abstract bool IsDead();
        public virtual Vector3 GetFoward => transform.forward;
        public virtual float GetSpeed => _Rb.velocity.magnitude;
    }
}