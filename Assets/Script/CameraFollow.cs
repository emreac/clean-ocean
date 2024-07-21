using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector2 offset = new Vector2(0f, 5f); // Offset from the target

    void Update()
    {
        if (target != null)
        {
            // Update camera position based on the target's position + offset
            Vector3 targetPos = target.position + new Vector3(offset.x, offset.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 5f); // Smoothly follow the target
        }
    }
}
