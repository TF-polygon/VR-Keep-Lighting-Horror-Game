using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objCominer : MonoBehaviour
{
    [SerializeField] private List<MeshFilter> sourceMeshFilters;
    [SerializeField] private MeshFilter targetMeshFilter;

    [ContextMenu(itemName: "Combine Meshes")]
    private void CombineMeshes()
    {
        var combine = new CombineInstance[sourceMeshFilters.Count];
        Vector3 averagePos = Vector3.zero;

        for (var i = 0; i < sourceMeshFilters.Count; i++)
        {
            combine[i].mesh = sourceMeshFilters[i].sharedMesh;
            combine[i].transform = sourceMeshFilters[i].transform.localToWorldMatrix;
            averagePos += sourceMeshFilters[i].transform.position;
        }

        averagePos /= sourceMeshFilters.Count; // Calculate average position

        var mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32; // Use UInt32 index format
        mesh.CombineMeshes(combine);
        targetMeshFilter.mesh = mesh;

        // Set the position of this GameObject to the average position of the combined meshes
        this.transform.position = averagePos;
    }
}