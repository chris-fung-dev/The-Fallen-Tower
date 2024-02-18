using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int Points_Needed_To_Spawn;
    public In_The_Can can_code;
   public GameObject Bear;
   public Transform Bear_SpawnPoint;
   
     void Update()
   {
       if (can_code.Point== Points_Needed_To_Spawn)
       {
           Instantiate(Bear, Bear_SpawnPoint);
       }
   }
}
