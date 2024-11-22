using UnityEngine;
using Fusion;

public class PlayerMeshChanger : NetworkBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;

    [Networked, OnChangedRender(nameof(MeshChange))]
    private int _meshInt{ get; set;}
    public AvatarSelector avatarSelector;
    public Mesh[] meshes;
    public Material[] materials;
    void MeshChange()
    {
        skinnedMeshRenderer.sharedMesh = meshes[_meshInt];
        skinnedMeshRenderer.material = materials[_meshInt];
    }
    public override void Spawned()
    {
        //_meshInt = avatarSelector.SelectedAvatar;
        skinnedMeshRenderer.sharedMesh = meshes[_meshInt];
        skinnedMeshRenderer.material = materials[_meshInt];
        avatarSelector = FindFirstObjectByType<Canvas>().GetComponent<AvatarSelector>();
        if(HasStateAuthority)
        {
            avatarSelector.OnAvatarChanged += Middleware;
        }
    }
    public void Middleware()
    {
        _meshInt = avatarSelector.SelectedAvatar;
    }
}
