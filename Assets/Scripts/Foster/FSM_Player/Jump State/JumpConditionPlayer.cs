using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zzzNico.Entities;
using zzzNico.FSM_SO_VERSION;

[CreateAssetMenu(fileName = "JumpCondition", menuName = "_main/Conditions/JumpCondition")]
public class JumpConditionPlayer : StateCondition
{
    public override bool CompleteCondition(EntityModel model)
    {
        return model.isJumping;
    }
}
