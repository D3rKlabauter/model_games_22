using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class transform : MonoBehaviour
{
    // Variables for player movement
    //public float moveSpeed = 5f;
    private Rigidbody rb;
    private bool isShapeChanged = false;
    private Vector3 originalScale;
    private Renderer playerRenderer;

    public Color[] colorOptions; // Array of colors for the player


    private void Start()
    {
        // Get the player's Rigidbody component
        rb = GetComponent<Rigidbody>();
        originalScale = transform.localScale;

        // Get the Renderer component to change the player's color
        playerRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        // Player movement controls
        /*
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        // Object interaction when the player enters a trigger collider
        if (other.CompareTag("Interactable"))
        {
            // Do something when interacting with the object
            Debug.Log("Interacting with object: " + other.gameObject.name);

            // Check if the player's shape has already changed
            if (!isShapeChanged)
            {
                // Change the player's shape
                Vector3 randomScale = new Vector3(Random.Range(0.5f, 2f), Random.Range(0.5f, 2f), Random.Range(0.5f, 2f));
                transform.localScale = randomScale;
                //transform.localScale = new Vector3(2f, 0.5f, 2f);
                //isShapeChanged = true;
            }

            // Change the player's color randomly
            Color randomColor = colorOptions[Random.Range(0, colorOptions.Length)];
            playerRenderer.material.color = randomColor;
        }
    }
}
