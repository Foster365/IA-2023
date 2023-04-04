using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    FSM<string> characterFSM;
    Character character;


    private void Awake()
    {
        character = GetComponent<Character>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CharacterFSMInit();
    }

    // Update is called once per frame
    void Update()
    {
        characterFSM.OnUpdate();
    }

    void CharacterFSMInit()
    {
        characterFSM = new FSM<string>();
        IdleStatePlayer<string> idleState = new IdleStatePlayer<string>(characterFSM, "MoveState", "JumpState", character);
        MoveStatePlayer<string> moveState = new MoveStatePlayer<string>(characterFSM, "IdleState", "JumpState", character, character.Rb);
        JumpStatePlayer<string> jumpState = new JumpStatePlayer<string>(characterFSM, "IdleState", character);

        idleState.AddTransition("MoveState", moveState);
        moveState.AddTransition("IdleState", idleState);

        idleState.AddTransition("JumpState", jumpState);
        jumpState.AddTransition("IdleState", idleState);

        moveState.AddTransition("JumpState", jumpState);

        characterFSM.SetInit(idleState);


    }

}
