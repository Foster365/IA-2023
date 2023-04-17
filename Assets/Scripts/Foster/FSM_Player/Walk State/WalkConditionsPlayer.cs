using UnityEngine;
using zzzNico.Entities;
using zzzNico.FSM_SO_VERSION;

namespace Foster.FSM_Player.Walk_State
{
    [CreateAssetMenu(fileName = "WalkCondition", menuName = "_main/Conditions/WalkCondition")]
    public class WalkConditionsPlayer : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            return model.isWalking;
        }
    }
}
