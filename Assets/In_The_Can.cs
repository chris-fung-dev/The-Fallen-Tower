using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class In_The_Can : MonoBehaviour
{
    public int Points_Needed;
    public int Point;
    public GameObject Key;
    public bool haskey;
    public bool Should_Spawner_New_Bear;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bear")
        {
            Destroy(other.gameObject);
            Point += 1;
        } 
    }

    private void Update()
    {
        if (Points_Needed == Point)
        {
            Key.SetActive(true);
            Point = 0;
            haskey = true;
        }
    }
}
