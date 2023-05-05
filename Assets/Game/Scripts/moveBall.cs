using UnityEngine;

public class moveBall : MonoBehaviour
{
    public float speed = 5f;
    public float rollSpeed = 10f;
    public float deceleration = 5f;

    private float rollAmount = 0f;
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        // Get horizontal and vertical input and calculate roll amount
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput == 0f)
        {
            rollAmount = 0f; // stop rolling if no input
            if (moveDirection.magnitude > 0)
            {
                moveDirection -= moveDirection.normalized * deceleration * Time.deltaTime;
                if (moveDirection.magnitude < 0.1f)
                {
                    moveDirection = Vector3.zero;
                }
            }
        }
        else
        {
            rollAmount += horizontalInput * rollSpeed * Time.deltaTime;
            rollAmount = Mathf.Clamp(rollAmount, -45f, 45f);
            moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        }

        // Rotate the ball around its forward axis to simulate rolling
        Quaternion roll = Quaternion.AngleAxis(rollAmount, transform.forward);
        transform.rotation = roll;

        // Move the ball in all directions based on input
        transform.position += moveDirection.normalized * speed * Time.deltaTime;
    }
}
