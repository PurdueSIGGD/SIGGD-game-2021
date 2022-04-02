using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConeRaycaster : MonoBehaviour
{
    [Range(1, 100)] [SerializeField] private int rayNum;

    [Range(10f, 180f)] [SerializeField] private float fov;
    [Range(0f, 360f)] [SerializeField] private float angleOffset;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform rayOrigin;
    [Range(0.1f, 30f)] [SerializeField] private float maxDistance;

    [SerializeField] private UnityEvent hit;
    [SerializeField] private NavmeshAgent navmeshAgent;
    private float centerAngle = 361;
    private List<Vector3> points;


    // Start is called before the first frame update
    void Start()
    {
        points = new List<Vector3>();
    }

    // public bool raycast() {
    //     return Raycast((_) => true);
    // }


    public RaycastHit2D Raycast(Predicate<RaycastHit2D> isValid) {
        float minAngle;
        float maxAngle;
        if (centerAngle > 360)
        {
            minAngle = navmeshAgent.compassDirection * 90 + angleOffset - fov / 2;
            maxAngle = navmeshAgent.compassDirection * 90 + angleOffset + fov / 2;
        }
        else
        {
            maxAngle = centerAngle + angleOffset - fov / 2f;
            minAngle = centerAngle + angleOffset + fov / 2f;
        }

        List<Vector3> temp = new List<Vector3>();
        for (int i = 0; i < rayNum; i++) {
            var interpo = (float)i / (float)(rayNum-1);

            var theta = Mathf.LerpAngle(minAngle, maxAngle, interpo) * Mathf.Deg2Rad;

            var rayDir = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
            var result = Physics2D.Raycast(rayOrigin.position, rayDir, maxDistance, layerMask);

            if (result.transform != null)
            {
                temp.Add(Vector2.zero + rayDir * result.distance);
            } else { 
                temp.Add(Vector2.zero + rayDir * maxDistance);
            }

            /*
            if (result && isValid(result)) {
                Debug.DrawRay(rayOrigin.position, rayDir * result.distance, Color.green);
                hit.Invoke();
                return result;
            }
            Debug.DrawRay(rayOrigin.position, rayDir * maxDistance, Color.red);
            */


        }
        points = temp;

        return new RaycastHit2D();
    }

    public void setCenterAngle(float value)
    {
        centerAngle = value;
    }

    public List<Vector3> getData()
    {
        return points;
    }

    // Update is called once per frame
    void Update()
    {
        // raycast();
    }
}
