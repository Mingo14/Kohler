﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohesionBehavior : AutonomousBehavior
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
                sum = sum + targetAgent.position;
            }
            sum = sum / gameObjects.Length;

            //seek to center position
            Vector3 desired = (sum - agent.position).normalized * agent.maxSpeed;
            steering = desired - agent.velocity;
        }
        
        return steering;
    }
}
