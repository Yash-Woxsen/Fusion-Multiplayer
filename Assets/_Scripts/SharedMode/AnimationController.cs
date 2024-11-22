using Fusion;
using UnityEngine;

public class AnimationController : NetworkBehaviour
{
    public Animator animator;

    [Networked] 
    private float MoveSpeed { get; set; }
    public float moveSpeedDebug;

    public CharacterController _controller;

    public override void FixedUpdateNetwork()
    {
        if(HasStateAuthority)
        {
            MoveSpeed = _controller.velocity.magnitude;
            moveSpeedDebug = MoveSpeed;
        }
    }

    // void UpdateAnimation()
    // {
    //     animator.SetFloat("MoveSpeed", MoveSpeed,0.15f, Time.deltaTime);
    // }
    // public override void Spawned()
    // {
    //     animator.SetFloat("MoveSpeed", MoveSpeed, 0.15f, Time.deltaTime);
    // }
    public override void Render()
    {
        animator.SetFloat("MoveSpeed", MoveSpeed, 0.15f, Time.deltaTime);
    }
}













// using Fusion;
// using UnityEngine;

// public class AnimationController : NetworkBehaviour
// {
//     public Animator Animator;
//     public CharacterController characterController;

//     [Header("Animation Parameters")]
//     [Networked] private int _animIDMoveSpeed { get; set; }
//     [Networked] private int _animIDIsGrounded { get; set; }
//     [Networked] private int _animIDFreefall { get; set; }
//     [Networked] private int _animIDMotionSpeed { get; set; }
//     [Networked] private int _animIDJumpTrigger { get; set; }

//     [Networked]
//     private NetworkBool _isJumping { get; set; }

//     public override void FixedUpdateNetwork()
//     {
//         if (characterController.isGrounded)
//         {
//             _isJumping = false;
//         }
//     }

//     public override void Render()
//     {

//         Animator.SetFloat(_animIDMoveSpeed, characterController.velocity.magnitude, 0.15f, Time.deltaTime);
//         Animator.SetFloat(_animIDMotionSpeed, 1f);
//         Animator.SetBool(_animIDJumpTrigger, _isJumping);
//         Animator.SetBool(_animIDIsGrounded, characterController.isGrounded);
//         Animator.SetBool(_animIDFreefall, characterController.velocity.y < -10f);
//     }

//     private void AssignAnimationIDs()
//     {
//         _animIDMoveSpeed = Animator.StringToHash("MoveSpeed");
//         _animIDIsGrounded = Animator.StringToHash("IsGrounded");
//         _animIDJumpTrigger = Animator.StringToHash("JumpTrigger");
//         _animIDFreefall = Animator.StringToHash("FreeFall");
//         _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");

//     }
//     public override void Spawned()
//     {
//         AssignAnimationIDs();
//     }
// }
