using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConeRaycaster : MonoBehaviour
{
    [Range(1, 10)] [SerializeField] private int rayNum;

    [Range(10f, 180f)] [SerializeField] private float fov;
    [Range(0f, 360f)] [SerializeField] private float angle;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform rayOrigin;
    [Range(0.1f, 30f)] [SerializeField] private float maxDistance;

    [SerializeField] private UnityEvent hit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool raycast() {
        var minAngle = angle - fov / 2f;
        var maxAngle = angle + fov / 2f;
        for (int i = 0; i < rayNum - 1; i++) {
            var interpo = (float)i / (float)(rayNum-1);

            var theta = Mathf.LerpAngle(minAngle, maxAngle, interpo) * Mathf.Deg2Rad;

            var rayDir = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
            var result = Physics2D.Raycast(rayOrigin.position, rayDir, maxDistance, layerMask);

            if (result) {
                Debug.DrawRay(rayOrigin.position, rayDir * result.distance, Color.red);
                hit.Invoke();
                return true;
            }
            Debug.DrawRay(rayOrigin.position, rayDir * maxDistance, Color.green);

        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        raycast();
    }
}
