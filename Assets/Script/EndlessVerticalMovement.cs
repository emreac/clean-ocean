using UnityEngine;

public class EndlessVerticalMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of movement

    private Rigidbody2D rb;
    private float screenHeight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Calculate the screen height in world coordinates
        screenHeight = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y;
    }

    void Update()
    {
        // Move the sprite upwards
        Vector2 newPos = rb.position + Vector2.up * moveSpeed * Time.deltaTime;
        rb.MovePosition(newPos);

        // If the sprite moves past the top edge of the screen, reset its position to the bottom edge
        if (transform.position.y > screenHeight)
        {
            Vector2 resetPos = new Vector2(transform.position.x, -screenHeight);
            rb.MovePosition(resetPos);
        }
    }
}
