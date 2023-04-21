using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zzzNico.Entities;
using zzzNico.Entities.Player;
using zzzNico.FSM_SO_VERSION;

[CreateAssetMenu(fileName = "JumpState", menuName = "_main/States/PlayerStates/JumpState", order = 0)]
public class JumpStatePlayer : State
{
    public override void ExecuteState(EntityModel model)

    {
        Debug.Log("Jupstate execute");
        PlayerModel playerModel = model as PlayerModel;
        playerModel.Jump();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Is jumping");
            playerModel.Jump();
        }
    }
}
