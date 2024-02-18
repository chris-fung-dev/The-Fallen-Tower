using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMusic : MonoBehaviour
{
     private AudioSource audioSource;
        private bool hasPlayed = false;
    
        void Start()
        {
            // Get the AudioSource component attached to the GameObject
            audioSource = GetComponent<AudioSource>();
    
            // Ensure the AudioSource is not set to loop
            audioSource.loop = true;
        }
    
        void Update()
        {
            // Check if the audio clip has not been played yet
            if (!hasPlayed)
            {
                // Check if the user wants to trigger the audio (you can replace this condition as needed)
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // Play the audio clip
                    audioSource.Play();
    
                    // Set the flag to true, indicating that the audio has been played
                    hasPlayed = true;
                }
            }
        }
}
