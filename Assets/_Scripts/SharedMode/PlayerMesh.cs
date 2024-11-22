using Fusion;
using UnityEngine;

public class PlayerMesh : NetworkBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;

    [Networked, OnChangedRender(nameof(MeshChange))]
    private int _meshInt{ get; set;}

    public Mesh[] meshes;
    public Material[] materials;
    void Update()
    {
        if (HasStateAuthority  && Input.GetKeyDown(KeyCode.E))
        {
            // Changing the material color here directly does not work since this code is only executed on the client pressing the button and not on every client.
            _meshInt = Random.Range(0, meshes.Length);
        }
    }
    void MeshChange()
    {
        skinnedMeshRenderer.sharedMesh = meshes[_meshInt];
        skinnedMeshRenderer.material = materials[_meshInt];
    }
    public override void Spawned()
    {
        skinnedMeshRenderer.sharedMesh = meshes[_meshInt];
        skinnedMeshRenderer.material = materials[_meshInt];
    }
}
