using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Splines;
public class PathRenderer : MonoBehaviour
{
    NavMeshPath _path;
    public Transform start;
    public Transform end;
    public LineRenderer lineRenderer;
    public SplineContainer splineContainer;

    void Start()
    {
        _path = new NavMeshPath();
        SetPoints();
    }
    void SetPoints()
    {
        NavMesh.CalculatePath(start.position, end.position, NavMesh.AllAreas, _path);
        Vector3[] corners = _path.corners;
        lineRenderer.positionCount = corners.Length;
        lineRenderer.SetPositions(corners);

        for (int i = 0; i < _path.corners.Length - 1; i++)
        {
            splineContainer.Spline.Add(corners[i]);
        }
    }
}
