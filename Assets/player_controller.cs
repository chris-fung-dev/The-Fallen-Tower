using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class bunny_controller : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

    public Vector3 player;
    // Update is called once per frame
    void Update()
    { 
            // MOVE BUNNY
            agent.SetDestination(player);
        
    }
}
