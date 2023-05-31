using UnityEngine;

public class AvoidPlayer : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 50f;
    public float moveSpeed = 5f;
    public float approachSpeed = 5f;
    public float jumpForce = 10f;
    public float jumpInterval = 2f;

    private bool isMoving = false;
    private Vector3 moveDirection;
    private Rigidbody rb;
    private bool isJumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if the player is within the detection radius
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            // Check if the player is moving
            if (player.GetComponent<Rigidbody>().velocity.magnitude <= 0.1f)
            {
                if (!isMoving)
                {
                    // Generate a random direction away from the player
                    moveDirection = (transform.position - player.position).normalized;
                    moveDirection += Random.insideUnitSphere;
                    moveDirection.Normalize();

                    isMoving = true;
                }

                // Move the object in the calculated direction
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            }
            else
            {
                // Calculate the direction towards the player
                moveDirection = (player.position - transform.position).normalized;

                // Move the object towards the player
                transform.Translate(moveDirection * approachSpeed * Time.deltaTime);
            }

            // Check if the object is not currently jumping
            if (!isJumping)
            {
                // Trigger the jump coroutine
                StartCoroutine(Jump());
            }
        }
        else
        {
            isMoving = false;
        }
    }

    
    private System.Collections.IEnumerator Jump()
    {
        // Set the jumping flag to true
        isJumping = true;

        // Apply upward force to simulate the jump
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Wait for the jump interval before allowing another jump
        yield return new WaitForSeconds(jumpInterval);

        // Set the jumping flag to false
        isJumping = false;
    }
    
}
