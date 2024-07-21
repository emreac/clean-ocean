using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacoom : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Garbage"))
        {
            Debug.Log("There is garbage!");
            Destroy(collision.gameObject);

        }

    }
}
