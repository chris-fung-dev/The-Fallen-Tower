using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public GameObject Bear;
    public Transform Bear_Spawn;
    private GameObject BearToDestroy;
    private bool canPickUp_Bear = false;
    private bool Bear_In_Slot;
    public GameObject BearToSpawn;
    public Transform player;
    public float throwForce = 10f;
    public float upwardForce = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bear") && !Bear_In_Slot)
        {
            canPickUp_Bear = true;
            BearToDestroy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bear"))
        {
            canPickUp_Bear = false;
            BearToDestroy = null;
        }
    }

    private void Update()
    {
        if (canPickUp_Bear && Input.GetKeyDown(KeyCode.E))
        {
            if (!Bear_In_Slot)
            {
                // Activate the Bear game object
                Bear.SetActive(true);
                // Destroy any object with the "Bear" tag
                Destroy(GameObject.FindGameObjectWithTag("Bear"));
                Bear_In_Slot = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Bear_In_Slot)
            {
                Bear.SetActive(false); // Deactivate the bear
                GameObject spawnedObject = Instantiate(BearToSpawn, Bear_Spawn.position, Quaternion.identity);
                Vector3 throwDirection = player.forward;
                Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
                rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
                Bear_In_Slot = false; // Reset bear slot
            }
            else
            {
                Debug.Log("Empty");
            }
        }
    }
}

