using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetectorScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            StartCoroutine(Jump());
        }
    }

    private IEnumerator Jump()
    {
        rb.velocity = new Vector2(0f, transform.localScale.y * 6f);
        yield return new WaitForSeconds(1);
    }
}
