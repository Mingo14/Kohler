using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparationBehavior : AutonomousBehavior
{
    public override Vector3 Execute(AutonomousAgent agent, AutonomousAgent target, string targetTag)
    {
        Vector3 steering = Vector3.zero;

        //get all agent game objects within perception radius
        GameObject[] gameObjects = AutonomousAgent.GetGameObjects(gameObject, targetTag, perception);
        if(gameObjects.Length > 0)
        {
            //get center of all agents in perception
            Vector3 sum = Vector3.zero;
            foreach(GameObject gameObject in gameObjects)
            {
                AutonomousAgent targetAgent = (gameObject) ? target.GetComponent<AutonomousAgent>() : null;
                Vector3 direction = agent.position - targetAgent.position;
                float distance = direction.magnitude;

                direction = direction.normalized;
                direction = direction / distance;

                sum = sum + direction;
            }

            Vector3 desired = sum.normalized * agent.maxSpeed;
            steering = desired - agent.velocity;
        }
        
        return steering;
    }
}
