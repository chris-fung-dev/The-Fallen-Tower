using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleElevator
{
    public class ElevatorController : MonoBehaviour
    {
        // UI Panels
        public Text FloorExt;
        public Text FloorInt;

        // Clips Audio
        [SerializeField] private AudioClip OpenClip = null;
        [SerializeField] private AudioClip ButtonClip = null;

        // Initial Floor
        public int startingFloor = 1;

        // Animator and AudioSource Elevator
        private Animator ElevatorAnimator = null;
        private AudioSource ElevatorSound = null;

        // Elevator parameters
        public float elevatorMoveDelay = 3f; // Time delay for elevator movement
        public int totalFloors = 10; // Total number of floors

        // Internal variables
        private int currentFloor;

        // Start is called before the first frame update
        void Start()
        {
            currentFloor = startingFloor;
            FloorExt.text = "" + currentFloor.ToString("f0");
            FloorInt.text = "" + currentFloor.ToString("f0");

            ElevatorAnimator = GetComponent<Animator>();
            ElevatorSound = GetComponent<AudioSource>();

            // Start elevator movement coroutine
            StartCoroutine(MoveElevatorCoroutine());
        }

        // Coroutine to move the elevator
        IEnumerator MoveElevatorCoroutine()
        {
            while (currentFloor <= totalFloors)
            {
                // Elevator is moving up
                currentFloor++;

                // Update UI elements
                FloorExt.text = "" + currentFloor.ToString("f0");
                FloorInt.text = "" + currentFloor.ToString("f0");

                // Wait for the elevatorMoveDelay
                yield return new WaitForSeconds(elevatorMoveDelay);

                // Check if the elevator has reached the top floor
                if (currentFloor == totalFloors)
                {
                    // Play open door animation and sound
                    ElevatorAnimator.Play("Open");
                    ElevatorSound.PlayOneShot(OpenClip, 1f);

                    // Perform any other actions needed when the elevator reaches the top floor

                    // Break out of the loop to stop elevator movement
                    break;
                }
            }
        }

        // Update is not needed for this scenario, you can remove it

        // ... (other functions remain unchanged)
    }
}
