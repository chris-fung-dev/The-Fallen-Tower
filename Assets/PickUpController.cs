using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public GameObject Bear;
    private GameObject objectToDestroy;
    private bool canPickUp = false;
    public GameObject objectToSpawn; // GameObject to spawn
    public Transform player; // Player's transform
    public float throwForce = 10f; 
    public float upwardForce = 2f;// Force to throw the object
    public Transform Bear_Spawn;
    private bool Bear_In_Slot;
    
    
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has the specified tag
        if (other.gameObject.CompareTag("Bear"))
        {
            canPickUp = true;
            objectToDestroy = other.gameObject;
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset the state if the object exits the trigger range
        if (other.gameObject.CompareTag("Bear"))
        {
            canPickUp = false;
            objectToDestroy = null;
        }
    }

    private void Update()
    {
        // Check for "E" key press
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            // Activate the Bear game object
            Bear.SetActive(true);
            // Destroy the object in the trigger range
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Bear");
            foreach(GameObject go in gos) Destroy(go);
            Bear_In_Slot = true;
        }
        if (Input.GetKeyDown(KeyCode.Q)) // Check for input to spawn and throw object
        {
            if (Bear_In_Slot)
            {
                Bear.SetActive(false);
                SpawnAndThrowObject();
                Bear_In_Slot = false;
            }
            else
            {
                Debug.Log("Empty");
            }
        }
    }

        void SpawnAndThrowObject()
        {
            // Spawn the object at the same position as the player
            GameObject spawnedObject = Instantiate(objectToSpawn, Bear_Spawn.position, Quaternion.identity);
            // Get the direction the player is facing
            Vector3 throwDirection = player.forward;
            // Apply force to the spawned object in the direction the player is facing
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
                
        }
        
    }
