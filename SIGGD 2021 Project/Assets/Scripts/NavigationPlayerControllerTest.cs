using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavmeshAgent))]
public class NavigationPlayerControllerTest : MonoBehaviour
{

    private NavmeshAgent navmeshAgent;
    private Vector2 target = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        navmeshAgent = gameObject.GetComponent<NavmeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenPos = Input.mousePosition;
            screenPos.z = 15f;
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPos);
            target = new Vector2(worldPoint.x, worldPoint.y);
            Debug.Log(target);
            
        }
        if (target != Vector2.zero)
        {
            Debug.DrawLine(transform.position, target, Color.grey);
            navmeshAgent.navigateTo(target);
        }
        if (Input.GetMouseButtonDown(1))
        {
            target = Vector2.zero;
        }
    }
}
