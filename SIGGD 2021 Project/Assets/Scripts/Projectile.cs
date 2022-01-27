using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask; //layerMask to check for collision
    [SerializeField] private int travelSpeed; //the speed the projectile travels
    [SerializeField] private float terminatingDistance; //distance where projectile terminates
    [SerializeField] private UnityEvent unityEvent;  //actions to carry out when projectile terminates
    
    private Vector3 origin;  //origin of the projectile
    private Rigidbody2D rigidbody;  //this object's rigidbody
    bool endStateTriggered;  //blocks unity event from triggering more than once.

    // Start is called before the first frame update
    void Start()
    {
        endStateTriggered = false;
        rigidbody = this.GetComponent<Rigidbody2D>();
        origin = this.transform.position;  //set origin

        //set projectile's velocity
        rigidbody.velocity = travelSpeed * this.GetComponent<ActivateProjectile>().getVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        //check if distance is reached
        float distance = Vector2.Distance(this.transform.position, origin);
        if (!endStateTriggered)
        {
            if(distance > terminatingDistance || rigidbody.IsTouchingLayers(layerMask))
            {
                Debug.Log("Hit something");
                rigidbody.isKinematic = true;
                rigidbody.velocity = Vector2.zero;
                unityEvent?.Invoke();
                endStateTriggered = true;
            }
        }
    }

    public void Destroy()
    {
        GameObject.Destroy(gameObject, 0);
    }
}
