using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.Idle
{
    
    [CreateAssetMenu(fileName = "IdleEnterCondition", menuName = "_main/Conditions/IdleEnterCondition")]
    public class IdleEnterCondition : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            return model.isIdle;
        }
    }
}