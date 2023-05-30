using UnityEngine;

public class AvoidPlayer : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 50f;
    public float moveSpeed = 5f;
    public float approachSpeed = 5f;

    private bool isMoving = false;
    private Vector3 moveDirection;

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
        }
        else
        {
            isMoving = false;
        }
    }
}
