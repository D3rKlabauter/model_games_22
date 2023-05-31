using UnityEngine;

public class AvoidPlayer : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 50f;
    public float moveSpeed = 5f;
    public float approachSpeed = 5f;

    private Vector3 moveDirection;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Check if the player is within the detection radius
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
           
           
            // Generate a random direction away from the player
            moveDirection = (transform.position - player.position).normalized;
            moveDirection += Random.insideUnitSphere;
            moveDirection.Normalize();
                

            // Move the object in the calculated direction
            rb.AddForce(moveDirection * moveSpeed);
            
            // add force


         }
        else
        {
            // Calculate the direction towards the player
            moveDirection = (player.position - transform.position).normalized;

            // Move the object towards the player
            rb.AddForce(moveDirection * approachSpeed);
            // add force
        }
    }
    
}
