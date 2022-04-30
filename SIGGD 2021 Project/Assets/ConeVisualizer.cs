using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ConeVisualizer : MonoBehaviour
{
    [SerializeField] private ConeRaycaster cone;
    [SerializeField] private List<Vector3> vertices;
    [SerializeField] private List<int> trianglesList;
    [SerializeField] private Mesh mesh;
    [SerializeField] private AIStateManager manager;
    private Behavior behavior;
    [SerializeField] private Material[] coneColors;
    private int[] triangles;

    void Start()
    {
        mesh = new Mesh();

        behavior = manager.activeState.behavior;
        
        GetComponent<MeshFilter>().mesh = mesh;
        trianglesList = new List<int>();
        //vertices = new List<Vector3>();
        for (int i = 2; i <= cone.getRayCount(); i++)
        {
            trianglesList.Add(0);
            trianglesList.Add(i - 1);
            trianglesList.Add(i);
        }
        triangles = trianglesList.ToArray();
        //Debug.Log(mesh.triangles);
    }

    // Update is called once per frame
    void Update()
    {
        vertices = cone.getData();
        mesh.vertices = vertices.ToArray();
        if (mesh.triangles.Length == 0 && vertices.Count - 1 == cone.getRayCount())
        {
            //Debug.Log("Debug");
            mesh.triangles = triangles;
        }
        GetComponent<MeshFilter>().mesh = mesh;
        Behavior newBehavior = manager.activeState.behavior;
        if (newBehavior != behavior) {
            if (newBehavior is ApproachPlayer) {
                GetComponent<MeshRenderer>().material = coneColors[2];
            } else if (newBehavior is ApproachSound || newBehavior is SearchForPlayer)
            {
                GetComponent<MeshRenderer>().material = coneColors[1];
            } else
            {
                GetComponent<MeshRenderer>().material = coneColors[0];
            }
        }
    }
}
