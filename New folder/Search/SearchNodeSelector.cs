using System.Collections.Generic;
using UnityEngine;

public class SearchNodeSelector : MonoBehaviour
{
    public enum eSearchType
    {
        DFS,
        BFS,
        DIJKSTRA,
        A_STAR
    }

    [SerializeField] Node m_source = null;
    [SerializeField] Node m_destination = null;
    [SerializeField] SearchAgent m_agent = null;
    [SerializeField] eSearchType m_searchType = eSearchType.DFS;
    [SerializeField] bool m_warpAgentToSource = false;

    private void Update()
    {
        SelectNodes();
    }

    public void Execute()
    {
        List<Node> path = null;
        switch (m_searchType)
        {
            case eSearchType.DFS:
                SearchDFS.Build(m_source, m_destination, out path);
                break;
            case eSearchType.BFS:
                SearchBFS.Build(m_source, m_destination, out path);
                break;
            case eSearchType.DIJKSTRA:
                //SearchDIJKSTRA.Build(m_source, m_destination, out path);
                break;
            case eSearchType.A_STAR:
                SearchAStar.Build(m_source, m_destination, out path);
                break;
            default:
                break;
        }
        if (path != null)
        {
            m_agent.waypoint = path[0].GetComponentInChildren<Waypoint>();
            if (m_warpAgentToSource)
            {
                m_agent.transform.position = m_agent.waypoint.transform.position;
            }
            for (int i = 0; i < path.Count - 1; i++)
            {
                Waypoint waypoint = path[i].GetComponentInChildren<Waypoint>();
                waypoint.nextWaypoint = path[i + 1].GetComponentInChildren<Waypoint>();
            }

            foreach (Node pathNode in path)
            {
                if (pathNode.type == Node.eType.STANDARD)
                {
                    pathNode.type = Node.eType.PATH;
                }
            }

            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Node");
            foreach(GameObject go in gameObjects)
            {
                Node node = go.GetComponent<Node>();
                if (node)
                {
                    if(node.visited && node.type == Node.eType.STANDARD)
                    {
                        node.type = Node.eType.VISITED;
                    }
                }
            }
        }
    }


    public void ResetNodes()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Node");
        foreach (GameObject go in gameObjects)
        {
            Node node = go.GetComponent<Node>();
            if (node && node.type != Node.eType.SOURCE && node.type != Node.eType.DESTINATION)
            {
                node.type = Node.eType.STANDARD;
            }
                node.visited = false;
                node.parentNode = null;
                node.cost = float.MaxValue;
            
        }
    }

    public void ResetSourceDestination()
    {
        m_source.type = Node.eType.STANDARD;
        m_source = null;
        m_destination.type = Node.eType.STANDARD;
        m_destination = null;
    }

    void SelectNodes()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                Node node = raycastHit.collider.gameObject.GetComponent<Node>();
                if (node)
                {
                    if (m_source == null)
                    {
                        node.type = Node.eType.SOURCE;
                        m_source = node;
                    }
                    else if (m_destination == null)
                    {
                        node.type = Node.eType.DESTINATION;
                        m_destination = node;
                    }
                }
            }
        }
    }
    Node GetRandomNode()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Node");
        GameObject go = gameObjects[Random.Range(0, gameObjects.Length)];
        Node node = go.GetComponent<Node>();

        return node;
    }

    public void RandomSource()
    {
        m_source = GetRandomNode();
        m_source.type = Node.eType.SOURCE;
    }

    public void RandomDestination()
    {
        m_destination = GetRandomNode();
        m_destination.type = Node.eType.DESTINATION;
    }
}