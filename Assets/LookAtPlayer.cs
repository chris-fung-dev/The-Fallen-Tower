using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
    
{
    public Transform playerTransform;
    public float rotationOffset = 90f; 
    public Transform target;
    public bool turnOff;
    void Update()
    {
        if (turnOff == false)
        {
            transform.LookAt(target);
        }
        else
        {
                // Calculate the direction to the player
                Vector3 directionToPlayer = playerTransform.position - transform.position;
                directionToPlayer.y = 0f; // Optional: Flatten the direction to the XZ plane

                // Calculate the target rotation based on the direction to the player with the offset
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer) * Quaternion.Euler(0f, rotationOffset, 0f);

                // Set the rotation to face the player with the offset
                transform.rotation = targetRotation;
            }
        }
        
    }
