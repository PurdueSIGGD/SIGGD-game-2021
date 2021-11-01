using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navmesh : MonoBehaviour
{
    public Vector2 center = Vector2.zero; //the center of the navmesh
    public int width = 2; //the width, in tiles, of the navmesh
    public int height = 2; //the height, in tiles, of  the navmesh
    public float tileSize = 1f; //the size of the tiles
    [SerializeField] private LayerMask layerMask;

    private List<NavmeshNode> navmeshNodes; //list of nodes in the navmesh

    private class NavmeshNode //a data structure consisting of a Vector2 pos and a list of adjacent NavmeshNodes 
    {
        public List<NavmeshNode> adjacentNodes;
        public Vector2 pos;
        public NavmeshNode(Vector2 pos)
        {
            this.pos = pos;
            this.adjacentNodes = new List<NavmeshNode>();
        }
        
    }
    
    private struct Point //a data structure consistion of a x and y float
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int x { get; set; }
        public int y { get; set; }
    }

    private class PathfindingNode //basically a wrapper for Navmesh node that includes some other fields that are used for the pathfinding algo 
    {
        public NavmeshNode node; 
        public float h; //heuristic. see heuristic function
        public float g; //the movement cost to move from the start to this node
        public float f; //sum of h and g
        public PathfindingNode parent; //parent pathfinding node

        public PathfindingNode(NavmeshNode node, float h, float g, float f, PathfindingNode parent)
        {
            this.node = node;
            this.h = h;
            this.g = g;
            this.f = f;
            this.parent = parent;
        }
    }

    private void Start()
    {
        navmeshNodes = generateNavmesh();
    }

    private List<NavmeshNode> generateNavmesh()
    {
        NavmeshNode[,] navmeshNodes = new NavmeshNode[width, height];
        List<NavmeshNode> ret = new List<NavmeshNode>(); //this will be a list of all accessible nodes on the mesh 

        //get world space positions for the nodes
        Vector2 tl = new Vector2(center.x - tileSize * width / 2, center.y + tileSize * height / 2);
        for (int x = 0; x < navmeshNodes.GetLength(0); x++)
        {
            for (int y = 0; y < navmeshNodes.GetLength(1); y++)
            {
                Vector2 pos = new Vector2(tl.x + x * tileSize + tileSize / 2, tl.y - y * tileSize - tileSize / 2);
                navmeshNodes[x, y] = new NavmeshNode(pos);
            }
        }
        //get adjacent nodes. if the node has at least 1 accessible node then add it to ret
        for (int x = 0; x < navmeshNodes.GetLength(0); x++)
        {
            for (int y = 0; y < navmeshNodes.GetLength(1); y++)
            {
                navmeshNodes[x, y].adjacentNodes = getAdjacentNodes(x, y, navmeshNodes);
                
                if (navmeshNodes[x, y].adjacentNodes.Count != 0)
                {
                    ret.Add(navmeshNodes[x, y]);
                }
            }
        }
        return ret; 
    }

    private List<NavmeshNode> getAdjacentNodes(int x, int y, NavmeshNode[,] navmeshNodes)
    {
        List<NavmeshNode> adjNodes = new List<NavmeshNode>();

        //possible positions for adjacent nodes
        Point[] adjArrayPositions =
        {
            new Point(x-1,y-1),
            new Point(x, y-1),
            new Point(x + 1, y - 1),
            new Point(x-1, y),
            new Point(x + 1, y),
            new Point(x-1, y + 1),
            new Point(x, y + 1),
            new Point(x + 1, y + 1)
        };

        foreach(Point arrPoint in adjArrayPositions)
        {
            if (isInBounds(arrPoint.x, arrPoint.y, navmeshNodes.GetLength(0), navmeshNodes.GetLength(1)))
            {
                NavmeshNode adjNode = navmeshNodes[arrPoint.x, arrPoint.y];
                RaycastHit2D hit = Physics2D.Linecast(navmeshNodes[x, y].pos , adjNode.pos, layerMask); //linecast from this node's position to adjacent node's position
                if (!hit) //if you did not hit anything then the node is accessible and can be added 
                {
                    adjNodes.Add(adjNode);
                }
            }
        }

        return adjNodes;
    }

    private bool isInBounds(int x, int y, int width, int height) //returns if a point is within the bounds of the array
    {
        if (x >= width || x < 0) { return false; }
        if (y >= height || y < 0) { return false; }
        return true;
    }

    public Vector2[] getPath(Vector2 start, Vector2 end) //pathfinding algo (A*)
    {
        NavmeshNode startNode = getClosestNodeTo(start);
        NavmeshNode endNode = getClosestNodeTo(end);

        // Debug.Log("Start Node Pos: " + startNode.pos);
        // Debug.Log("End Node Pos: " + endNode.pos);

        List<PathfindingNode> openList = new List<PathfindingNode>();
        List<PathfindingNode> closedList = new List<PathfindingNode>();

        PathfindingNode pathfindingStartNode = new PathfindingNode(startNode, 0, 0, 0, null);
        openList.Add(pathfindingStartNode);

        while(openList.Count > 0)
        {
            
            //find node with lowest f on open list and call it q
            PathfindingNode q = openList[0];
            foreach(PathfindingNode node in openList)
            {
                if (node.f < q.f)
                {
                    q = node;
                }
            }    

            //pop q off the open list
            openList.Remove(q);

            //generate q's successors and set their parents to q
            PathfindingNode[] successors = generateSuccessors(q.node.adjacentNodes, end, q);
            
            //for each successor
            for (int i = 0; i < successors.Length; i++)
            {
                PathfindingNode successor = successors[i];
                    
                //if successor is the end node
                if (successor.node.pos == endNode.pos)
                {
                    //generate path to end node and return
                    List<NavmeshNode> path = new List<NavmeshNode>();
                    while (successor != null)
                    {
                        path.Add(successor.node);
                        successor = successor.parent;
                    }
                    int k = 0;
                    Vector2[] ret = new Vector2[path.Count];
                    for (int j =  path.Count - 1; j >= 0; j--)
                    {
                        ret[j] = path[k].pos;
                        k++;
                    }
                    return ret;
                }

                //if a node with the same position as successor is in the open list which has a lower f than successor, skip this successor
                if (fasterNodeInList(openList, successor))
                {
                    continue;
                }
                //if a node with the same position as successor is in the closed list which has a lower f than successor, skip this successor
                if (fasterNodeInList(closedList , successor))
                {
                    continue;
                }
                //otherwise add the node to the open list
                openList.Add(successor);

            }
            //add q to the closed list
            closedList.Add(q);
        }

        Debug.Log("wasn't able to find path");
        return new Vector2[0];
    }
    private float calculateHeuristic(Vector2 nodePos, Vector2 endPos) //calculates a heuristic using a heuristic function
    {
        /*
         * The heuristic is the estimated movement cost to get from one position to another. It's essentially what differentiates A* from other algos like Dijkstra. It's cool because it allows you
         * to intelligently pick the next node to search instead of treating all adjacent nodes as equal. There are lots of different ways to calculate a heuristic but the simplest one is just the
         * getting the distance between nodes and that's what I do here
         */
        return Vector2.Distance(nodePos, endPos);
    }
    private PathfindingNode[] generateSuccessors(List<NavmeshNode> adjacentNodes, Vector2 endLocation, PathfindingNode parentNode) //generates a list of pathfinding nodes from the adjacent nodes of a navmesh node
    {
        PathfindingNode[] pathfindingNodes = new PathfindingNode[adjacentNodes.Count];
        for (int i = 0; i < adjacentNodes.Count; i++) 
        {
            NavmeshNode node = adjacentNodes[i];
            float h = calculateHeuristic(node.pos, endLocation);
            float g = parentNode.g + Vector2.Distance(node.pos, parentNode.node.pos);
            float f = g + h;
            pathfindingNodes[i] = new PathfindingNode(node, h, g, f, parentNode);
        }
        return pathfindingNodes;
    } 
    private bool fasterNodeInList(List<PathfindingNode> list, PathfindingNode node)
    {
        //if there is a node in list with the same position as node and a lower f than node then return true else return false
        foreach(PathfindingNode currentNode in list)
        {
            if (currentNode.node.pos == node.node.pos && currentNode.f < node.f)
            {
                return true;
            }
        }
        return false;
    }
    private NavmeshNode getClosestNodeTo(Vector2 pos) //gets the closest node on the navmesh to the Vector2 position
    {
        NavmeshNode closestNode = navmeshNodes[0];
        float closestNodeDist = Vector2.Distance(pos, closestNode.pos);
        foreach(NavmeshNode node in navmeshNodes)
        {
            float dist = Vector2.Distance(pos, node.pos);
            if (dist < closestNodeDist)
            {
                closestNodeDist = dist;
                closestNode = node;
            }
        }
        return closestNode;
    }
    /*
    private void OnDrawGizmos() //draw things
    {
        
        Vector2 tl = new Vector2(center.x - tileSize * width/2, center.y + tileSize * height/2);
        Vector2 tr = new Vector2(tl.x + width * tileSize, tl.y);
        Vector2 br = new Vector2(tr.x, tr.y - height * tileSize);
        Vector2 bl = new Vector2(br.x - width * tileSize, br.y);


        Gizmos.color = Color.black;
        Gizmos.DrawLine(tl, tr);
        Gizmos.DrawLine(tr, br);
        Gizmos.DrawLine(br, bl);
        Gizmos.DrawLine(bl, tl);

        Gizmos.color = Color.green;
        if (navmeshNodes == null)
        {
            return;
        }
        
        foreach (NavmeshNode node in navmeshNodes)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(node.pos, 0.1f);
            foreach (NavmeshNode adjNode in node.adjacentNodes)
            {
                Gizmos.DrawLine(node.pos, adjNode.pos);
            }
        }
        
    }
    */
}
