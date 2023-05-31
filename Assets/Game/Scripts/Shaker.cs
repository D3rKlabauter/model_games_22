using UnityEngine;

public class Shaker : MonoBehaviour
{
    public Transform box;
    public GameObject[] spheres;

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
        // Shake the box based on mouse movement
        float shakeX = Input.GetAxis("Mouse X");
        float shakeY = Input.GetAxis("Mouse Y");

        box.position = new Vector3(shakeX, 0f, shakeY);


    }
}
