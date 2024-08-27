using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;
public class END : MonoBehaviour
{
    public In_The_Can key;
    public bool open;
    private void Update()
    {
        if (key.Points_Needed == key.Point)
        {
            open = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (open)
        {
            SceneManager.LoadScene(0); 
        }
    }
}
