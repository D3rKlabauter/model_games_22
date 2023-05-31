using UnityEngine;

public class Shaker : MonoBehaviour
{
    public Transform box;
    public GameObject[] spheres;
    public float shakeIntensity = 1f;
    public float fallSpeed = 2f;
    public float rotationSpeed = 5f;

    private Vector3 initialBoxPosition;
    private Quaternion initialBoxRotation;

    private void Start()
    {
        // Store the initial position and rotation of the box
        initialBoxPosition = box.position;
        initialBoxRotation = box.rotation;
    }

    private void Update()
    {
        // Check if the mouse cursor is moving
        if (Input.GetAxis("Mouse X") != 0f || Input.GetAxis("Mouse Y") != 0f)
        {
            // Shake the box based on mouse movement
            float shakeX = Input.GetAxis("Mouse X") * shakeIntensity;
            float shakeY = Input.GetAxis("Mouse Y") * shakeIntensity;

            box.position = initialBoxPosition + new Vector3(shakeX, shakeY, 0f);
        }
        else
        {
            // Make the box fall down slowly
            box.position = Vector3.Lerp(box.position, initialBoxPosition, fallSpeed * Time.deltaTime);
        }

        // Rotate the box slowly
        box.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Apply impulses to the spheres inside the box
        foreach (GameObject sphere in spheres)
        {
            Rigidbody rb = sphere.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Random.insideUnitSphere * shakeIntensity, ForceMode.Impulse);
            }
        }
    }
}
