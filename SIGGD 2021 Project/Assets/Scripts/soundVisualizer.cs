using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class soundVisualizer : MonoBehaviour
{
    [SerializeField] private CircleCollider2D signal;
    [SerializeField] private List<Vector3> vertices;
    [SerializeField] private List<int> trianglesList;
    [SerializeField] private Mesh mesh;
    [SerializeField] private float resolution = 64;
    private int[] triangles;

    void Start()
    {
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;
        trianglesList = new List<int>();
        //vertices = new List<Vector3>();
        for (int i = 2; i <= resolution; i++)
        {
            trianglesList.Add(0);
            trianglesList.Add(i - 1);
            trianglesList.Add(i);
        }
        trianglesList.Add(0);
        trianglesList.Add(1);
        trianglesList.Add((int)resolution);
        triangles = trianglesList.ToArray();
        Debug.Log(mesh.triangles);
    }

    // Update is called once per frame
    void Update()
    {
        //update circle size
        vertices = new List<Vector3>();
        if (signal.radius > 0.1f)
        {
            for (int i = 0; i < resolution; i++)
            {
                Vector3 pointPos = new Vector3(Mathf.Sin((2 * Mathf.PI * i) / resolution), Mathf.Cos((2 * Mathf.PI * i) / resolution), 0) * signal.radius;
                vertices.Add(pointPos);
                //Debug.DrawRay(transform.position, pointPos, Color.green);
            }
            vertices.Insert(0, Vector3.zero);

            //set mesh
            mesh.vertices = vertices.ToArray();
            if (mesh.triangles.Length == 0 && vertices.Count - 1 == resolution)
            {
                Debug.Log("Debug 2");
                mesh.triangles = triangles;
            }
            GetComponent<MeshFilter>().mesh = mesh;
        } else
        {
            GetComponent<MeshFilter>().mesh = null;
        }
        

        
    }
}
