using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float attractionForce = 10f;
    [SerializeField] private float maxDistance = 5f;

    void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, maxDistance);

        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = transform.position - collider.transform.position;
                rb.AddForce(direction.normalized * attractionForce * Time.fixedDeltaTime);
            }
        }
    }
}
