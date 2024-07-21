using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public Joystick moveJoystick;
    public float playerSpeed = 5f;
    public float rotationAngle = 45f; // Angle to rotate when moving left or right
    public float rotationSpeed = 5f; // Speed of rotation

    private Rigidbody2D rb;
    private Vector2 minScreenBounds;
    private Vector2 maxScreenBounds;
    private Quaternion targetRotation = Quaternion.identity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
       

        // Recalculate screen boundaries in world coordinates
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, 0));

        float moveHorizontal = moveJoystick.Direction.x;
        float moveVertical = moveJoystick.Direction.y;

        // Calculate movement direction and apply speed
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * playerSpeed;

        // Calculate target rotation based on joystick direction
        if (moveHorizontal < 0) // Moving left
        {
            targetRotation = Quaternion.Euler(0, 0, rotationAngle);
        }
        else if (moveHorizontal > 0) // Moving right
        {
            targetRotation = Quaternion.Euler(0, 0, -rotationAngle);
        }
        else // No horizontal movement
        {
            targetRotation = Quaternion.identity; // Reset rotation
        }

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Clamp player position to screen boundaries
        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minScreenBounds.x, maxScreenBounds.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minScreenBounds.y, maxScreenBounds.y);
        transform.position = clampedPosition;
    }
}
