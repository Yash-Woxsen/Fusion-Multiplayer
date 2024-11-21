using Fusion;
using UnityEngine;

public class PlayerMesh : NetworkBehaviour
{
    public MeshFilter meshFilter;

    [Networked, OnChangedRender(nameof(MeshChange))]
    private int _meshInt{ get; set;}

    public Mesh[] meshes;
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
        meshFilter.mesh = meshes[_meshInt];
    }
    public override void Spawned()
    {
        meshFilter.mesh = meshes[_meshInt];
    }
}
