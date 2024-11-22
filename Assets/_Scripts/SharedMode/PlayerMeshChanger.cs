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
    // void ChangeMesh()
    // {
    //     if (HasStateAuthority)
    //     {
    //         // Changing the material color here directly does not work since this code is only executed on the client pressing the button and not on every client.
    //         _meshInt = Random.Range(0, meshes.Length);
    //     }
    // }
    void MeshChange()
    {
        if(HasStateAuthority)
        {
            _meshInt = avatarSelector.SelectedAvatar;
            skinnedMeshRenderer.sharedMesh = meshes[_meshInt];
            skinnedMeshRenderer.material = materials[_meshInt];
        }
    }
    public override void Spawned()
    {
        avatarSelector = FindFirstObjectByType<Canvas>().GetComponent<AvatarSelector>();
        _meshInt = avatarSelector.SelectedAvatar;
        skinnedMeshRenderer.sharedMesh = meshes[_meshInt];
        skinnedMeshRenderer.material = materials[_meshInt];

        avatarSelector.OnAvatarChanged += MeshChange;
    }

}
