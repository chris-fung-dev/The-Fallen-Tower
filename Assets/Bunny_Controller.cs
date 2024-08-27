using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Bunny_Controller : MonoBehaviour
{
    public Transform target; // Set the target (player to follow) in the Inspector
    public NavMeshAgent agent;
    public AudioSource hello; // Reference to the AudioSource component
    public float delayInSeconds = 5f;
    public float soundInterval = 5f; // Interval between playing the sound

    private void Start()
    {
        agent.updateRotation = false;

        // Check if AudioSource is assigned
        if (hello == null)
        {
            // If AudioSource is not assigned, try to find it on this GameObject
            hello = GetComponent<AudioSource>();

            // If AudioSource is still not found, log an error
            if (hello == null)
            {
                Debug.LogError("AudioSource component is not found on " + gameObject.name);
            }
        }

        // Start the coroutine to play the sound after the delay
        StartCoroutine(PlaySoundDelayed());
    }

    // Coroutine to play the sound after the delay
    private IEnumerator PlaySoundDelayed()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayInSeconds);

        // Play the sound continuously with the specified interval
        while (true)
        {
            hello.Play();
            yield return new WaitForSeconds(soundInterval); // Wait for the specified interval before playing the sound again
        }
    }

    private void Update()
    {
        if (target != null)
        {
            // MOVE BUNNY
            agent.SetDestination(target.position);
        }
    }
}