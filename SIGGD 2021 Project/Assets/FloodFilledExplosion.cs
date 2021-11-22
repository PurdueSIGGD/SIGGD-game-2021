using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodFilledExplosion : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject origin;
    [SerializeField] private LayerMask layer;
    [SerializeField] private int maxIteration;
    [SerializeField] private float delay;
    public bool original; // set to false to prevent clones to run this script

    private int currIteration = 0;
    private double timeSinceLastRun = 0;
    private List<GameObject> explosions = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (original) 
        {
            explosions.Add(origin);
            FloodFill();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (original)
        {
            Debug.Log("Is active");
            FloodFill();
        }
    }

    void FloodFill()
    {
        if (currIteration < maxIteration) // check if maxIteration is reached. Runs if not.
        {
            if (timeSinceLastRun < delay) // check if delay interval is reached. Runs not reached.
            {
                timeSinceLastRun += Time.deltaTime;
                return;
                // Adds delta time to tineSinceLastRun and returns
            }

            currIteration++;
            timeSinceLastRun = 0;

            // temp list to store new origins to floodfill from

            List<GameObject> tempList = new List<GameObject>();


            for (int index = 0; index < explosions.Count; index++) 
            {
            Vector3 explosionPos = explosions[index].transform.position;
            Quaternion rotation = origin.transform.rotation;
            float colliderSize = origin.GetComponent<BoxCollider2D>().size.x;

            addToList(tempList, Clone(explosions[index],
                explosionPos + colliderSize * Vector3.up, rotation));
            addToList(tempList, Clone(explosions[index],
                explosionPos + colliderSize * Vector3.down, rotation));
            addToList(tempList, Clone(explosions[index],
                explosionPos + colliderSize * Vector3.right, rotation));
            addToList(tempList, Clone(explosions[index],
                explosionPos + colliderSize * Vector3.left, rotation));
            }  // Runs through every element in the list and clones itself 4 times (north, south, east, west)

            explosions.Clear();
            explosions = tempList;
        }
        else
        {
            GameObject.Destroy(parent, delay);
        }
    }

    void addToList(List<GameObject> list, GameObject obj)
    {
        if (obj != null)
        {
            list.Add(obj);
        }
    }  // adds object to list if it is non NUll

    GameObject Clone(GameObject explosion, Vector3 explosionPos, Quaternion rotation)
    {
        if (Physics2D.OverlapBox(explosionPos, new Vector2((float) .1, (float) .1),
            0, layer, -1, 1) != null)
        {
            return null;
        } //checks if a wall is in the way
        GameObject clone = GameObject.Instantiate(explosion, explosionPos,
                rotation, parent.transform);

        clone.GetComponent<FloodFilledExplosion>().original = false;
        return clone;
    } // clone the explosion object at explosionPos. Sets original of cloned obj to false    
}