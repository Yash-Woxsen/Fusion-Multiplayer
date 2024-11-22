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
            MoveSpeed = _controller.velocity.normalized.magnitude;
            moveSpeedDebug = MoveSpeed;
        }
    }
    public override void Render()
    {
        animator.SetFloat("MoveSpeed", MoveSpeed, 0.15f, Time.deltaTime);
    }
}