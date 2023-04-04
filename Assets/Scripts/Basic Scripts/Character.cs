using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] float runSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;

    Rigidbody rb;

    HealthController hc;

    public Rigidbody Rb { get => rb; set => rb = value; }
    public float RunSpeed { get => runSpeed; set => runSpeed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, -transform.up, 2f, 1 << LayerMask.NameToLayer("Ground")) ? true : false;
    }

    public void Jump()
    {
        rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        CheckGround();
        Debug.Log("Grounded? " + isGrounded);
    }

    public void Move(Vector3 dir)
    {
        if (isGrounded)
        {
            dir.y = 0;
            rb.velocity = dir * runSpeed;
            if (dir.x != 0 || dir.z != 0)
                transform.forward = dir;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
