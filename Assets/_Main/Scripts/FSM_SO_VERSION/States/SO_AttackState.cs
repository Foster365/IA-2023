using _Main.Scripts.Entities;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States
{
    public class SO_AttackState : State
    {
        [SerializeField] private EntityModel targetModel;
        [SerializeField] private float attackRange;
        [SerializeField] private LayerMask affectedMask;
        public override void EnterState(EntityModel model){}

        public override void ExecuteState(EntityModel model)
        {
            var dirToTarget = (targetModel.transform.position - model.transform.position);
            
            if (Physics.Raycast(model.transform.position,dirToTarget, attackRange, affectedMask))
            {
                model.DoDamage(targetModel);
            }
        }

        public override void ExitState(EntityModel model)
        {
            base.ExitState(model);
        }
    }
}