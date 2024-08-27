using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KillAnimation : MonoBehaviour
{
 public float delayInSeconds = 5f; 
  public  Animator myAnimationController;
  public LookAtPlayer look;
  public float wait = 1f;
  public AudioSource hit;
 private void OnTriggerEnter(Collider other) 
 { 
  if (other.gameObject.tag == "Player")
  {
   look.turnOff = true;
   myAnimationController.SetBool("Attack", true);
   Debug.Log("hit");
   Invoke("Attack", wait);
   Invoke("LoadScene", delayInSeconds);
  
 }

  
 }
   void LoadScene()
   {
    SceneManager.LoadScene(1); // Replace '1' with the index of the scene you want to load
   }

   void Attack()
   {
     hit.Play();

   }
}



 

