using Fusion;
using UnityEngine;

public class AnimationController : NetworkBehaviour
{
    public Animator animator;
    public Avatar avatarM, avatarF;

    [Networked] 
    private float MoveSpeed { get; set; }
    public float moveSpeedDebug;
    PlayerMeshChanger playerMeshChanger;
    public CharacterController _controller;

    public override void Spawned()
    {
        if(HasStateAuthority == false)
            return;

        playerMeshChanger = GetComponent<PlayerMeshChanger>();
        playerMeshChanger.OnMeshChanged += updateAnimatorAvatar;
    }
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

    void updateAnimatorAvatar()
    {
        if(playerMeshChanger.meshMaterialPairs[playerMeshChanger._meshInt].gender == Gender.male)
        {
            animator.avatar = avatarM;
        }
        else
        {
            animator.avatar = avatarF;
        }
    }
}