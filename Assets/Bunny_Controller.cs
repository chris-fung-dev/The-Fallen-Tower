using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;


public class Bunny_Controller : MonoBehaviour
{
    public Transform target; // Set the target (player to follow) in the Inspector
    public NavMeshAgent agent;

    void Start()
    {
        agent.updateRotation = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // MOVE PLAYER
            agent.SetDestination(target.position);
        }
            // Apply the target rotation to the object
  
        }
    }

