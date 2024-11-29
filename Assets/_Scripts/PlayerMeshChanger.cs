using Fusion;
using UnityEngine;
using System.Collections.Generic;

public class PlayerMeshChanger : NetworkBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;

    [Networked, OnChangedRender(nameof(MeshChange)),HideInInspector]
    public int _meshInt{ get; set;}
    public event System.Action OnMeshChanged;
    public AvatarSelector avatarSelector;
    //public Mesh[] meshes;
    //public Material[] materials;
    public bool isMale;
    public List<MeshMaterial> meshMaterialPairs = new List<MeshMaterial>();
    void MeshChange()
    {
        skinnedMeshRenderer.sharedMesh = meshMaterialPairs[_meshInt].mesh;
        skinnedMeshRenderer.material = meshMaterialPairs[_meshInt].material;

        OnMeshChanged?.Invoke();
    }
    public override void Spawned()
    {
        //_meshInt = avatarSelector.SelectedAvatar;
        skinnedMeshRenderer.sharedMesh = meshMaterialPairs[_meshInt].mesh;
        skinnedMeshRenderer.material = meshMaterialPairs[_meshInt].material;
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

[System.Serializable]
public class MeshMaterial
{
    public Mesh mesh;       // Mesh reference
    public Material material; // Material reference
    public Gender gender;
}
public enum Gender{ male,female}