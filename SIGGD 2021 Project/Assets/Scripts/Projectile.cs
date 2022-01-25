using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask; //layerMask to check for collision
    [SerializeField] private int travelSpeed; //the speed the projectile travels
    [SerializeField] private float terminatingDistance; //distance where projectile terminates
    [SerializeField] private Transform orientation;
    //a transform to calculate the distance the projectile travels

    [SerializeField] private UnityEvent unityEvent;
    //actions to carry out when projectile terminates
    
    private Vector3 origin;  //origin of the projectile
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        origin = this.transform.position;  //set origin

        //calculate and set projectile's velocity
        Vector2 velocity = orientation.position - origin;
        rigidbody.velocity = travelSpeed * velocity.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //check if distance is reached
        float distance = Vector2.Distance(this.transform.position, origin);
        if (distance > terminatingDistance || rigidbody.IsTouchingLayers(layerMask))
        {
            rigidbody.isKinematic = true;
            rigidbody.velocity = Vector2.zero;
            unityEvent?.Invoke();
        }
    }


}
