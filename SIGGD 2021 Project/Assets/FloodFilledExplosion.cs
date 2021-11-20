using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodFilledExplosion : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] private int explosionRadius;
    public bool original = true;

    private Vector3 origin;
    private Vector3 north = new Vector3(0, 1, 0);
    private Vector3 south = new Vector3(0, -1, 0);
    private Vector3 east = new Vector3(1, 0, 0);
    private Vector3 west = new Vector3(-1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        origin = explosion.transform.position;
        if (original)
        {
            FloodFill(explosion);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FloodFill(GameObject explosion)
    {
        Vector3 explosionPos = explosion.transform.position;
        Quaternion rotation = explosion.transform.rotation;
        if (Vector3.Distance(origin, explosion.transform.position) < explosionRadius)
        {
            FloodFill(Clone(explosion, explosionPos + north,
                rotation));
            FloodFill(Clone(explosion, explosionPos + south,
                rotation));
            FloodFill(Clone(explosion, explosionPos + east,
                rotation));
            FloodFill(Clone(explosion, explosionPos + west,
                rotation));
        }
        else
        {
            return;
        }
    }

    GameObject Clone(GameObject explosion, Vector3 explosionPos, Quaternion rotation)
    {
        GameObject clone = GameObject.Instantiate(explosion, explosionPos,
                rotation);
        clone.GetComponent<FloodFilledExplosion>().original = false;
        return clone;
    }

    void Terminate()
    {
        this.enabled = false;
    }
}
