using UnityEngine;

public class moveBall : MonoBehaviour
{
    // Variables for player movement
    public float moveSpeed = 5f;
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
        // Get the cursor position in the game world
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.y = transform.position.y; // Maintain the player's y position

        // Move the player towards the cursor position
        rb.MovePosition(Vector3.MoveTowards(transform.position, cursorPosition, moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        // Object interaction when the player enters a trigger collider
        if (other.CompareTag("ColorChanger"))
        {
            // Change the player's color randomly
            Color randomColor = colorOptions[Random.Range(0, colorOptions.Length)];
            playerRenderer.material.color = randomColor;
        }
        else if (other.CompareTag("ShapeChanger"))
        {
            // Check if the player's shape has already changed
            if (!isShapeChanged)
            {
                // Generate a random scale
                Vector3 randomScale = new Vector3(Random.Range(0.5f, 2f), Random.Range(0.5f, 2f), Random.Range(0.5f, 2f));
                transform.localScale = randomScale;
                isShapeChanged = true;
            }
        }
    }
}
