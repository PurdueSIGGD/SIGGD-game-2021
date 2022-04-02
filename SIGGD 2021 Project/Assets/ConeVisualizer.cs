using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ConeVisualizer : MonoBehaviour
{
    [SerializeField] private ConeRaycaster cone;
    [SerializeField] private List<Vector3> vertices;
    [SerializeField] private List<int> triangles;
    [SerializeField] private Transform transform;
    [SerializeField] private SeeFaction seePlayer;
    private Mesh mesh;

    void Start()
    {
        mesh = new Mesh();
        
        GetComponent<MeshFilter>().mesh = mesh;
        triangles = new List<int>();
        //vertices = new List<Vector3>();
        for (int i = 2; i <= cone.getRayCount(); i++)
        {
            triangles.Add(0);
            triangles.Add(i - 1);
            triangles.Add(i);
        }       
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MeshFilter>().mesh != null && seePlayer.isActive())
        {
            GetComponent<MeshFilter>().mesh = null;
            return;
        } 
        else if (GetComponent<MeshFilter>().mesh == null)
        {
            GetComponent<MeshFilter>().mesh = mesh;
        }
        vertices = cone.getData();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
    }
}
