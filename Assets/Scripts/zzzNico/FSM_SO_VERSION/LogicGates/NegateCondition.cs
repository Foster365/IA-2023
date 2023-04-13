using UnityEngine;
using zzzNico.Entities;

namespace zzzNico.FSM_SO_VERSION.LogicGates
{
    [CreateAssetMenu(fileName = "AndCondition", menuName = "_main/Conditions/Logic/NEGATE")]
    public class NegateCondition : StateCondition
    {
        [SerializeField] private StateCondition condition;
        public override bool CompleteCondition(EntityModel model)
        {
            return !condition.CompleteCondition(model);
        }
    }
}