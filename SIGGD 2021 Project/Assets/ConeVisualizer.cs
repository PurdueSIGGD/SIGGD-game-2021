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
    private Mesh mesh;

    // makes accessing data array more readable

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        
        GetComponent<MeshFilter>().mesh = mesh;
        triangles = new List<int>();
        vertices = new List<Vector3>();
        vertices = cone.getData();
        for (int i = 2; i < vertices.Count; i++)
        {
            triangles.Add(0);
            triangles.Add(i - 1);
            triangles.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        vertices = cone.getData();
        vertices.Insert(0, Vector3.zero);
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
