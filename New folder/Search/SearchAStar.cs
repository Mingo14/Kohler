using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;

public static class SearchAStar
{
    public static void Build(Node source, Node destination, out List<Node> path)
    {
        SimplePriorityQueue<Node> nodes = new SimplePriorityQueue<Node>();

        source.visited = true;
        source.cost = 0.0f;
        source.heuristic = (destination.transform.position - source.transform.position).magnitude;
        nodes.Enqueue(source, source.cost + source.heuristic);

        bool found = false;
        while (nodes.Count > 0) //looking at the top
        {
            Node node = nodes.Dequeue();
            if (node == destination)
            {
                found = true;
            }

            foreach (Node.Edge edge in node.edges)
            {
                Node childNode = edge.nodeB;
                if (childNode.visited) continue;

                float nodeCost = node.cost + (node.transform.position - childNode.transform.position).magnitude;

                if (nodeCost < childNode.cost)
                {

                    childNode.parentNode = node;
                    childNode.cost = node.cost;
                    childNode.heuristic = (destination.transform.position - childNode.transform.position).magnitude;
                    if (nodes.Contains(childNode) == false)
                    {
                        nodes.Enqueue(childNode, childNode.cost);
                    }

                }
            }
        }
        path = new List<Node>();
        if (found)
        {
            Node node = destination;
            while (node)
            {
                path.Add(node);
                node = node.parentNode;
            }
            path.Reverse();
        }

    }

}