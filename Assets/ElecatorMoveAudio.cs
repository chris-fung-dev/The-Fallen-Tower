using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecatorMoveAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            source.PlayOneShot(clip);
        }
    }
}
