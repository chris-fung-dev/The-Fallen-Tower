using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAnimation : MonoBehaviour
{
  public  Animator myAnimationController;
  public LookAtPlayer look;
 private void OnTriggerEnter(Collider other) 
 { 
  if (other.gameObject.tag == "Player")
  {
   look.turnOff = true;
   myAnimationController.SetBool("Attack", true);
   Debug.Log("hit");
  }

 }
}


 

