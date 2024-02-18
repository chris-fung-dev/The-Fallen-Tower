using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Door : MonoBehaviour
{
    public Animator anim;
   
    public bool Close_To_Door;

    public In_The_Can key;
    public GameObject Key;
    void Update()
    {
        if (Close_To_Door && key.haskey)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                anim.SetBool("Open", true);
                key.haskey = false;
                Key.SetActive(false);
                
            }
        }

        if (key.haskey)
        {
            Debug.Log("hello");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Close_To_Door = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Close_To_Door = false;
        }
    }
}