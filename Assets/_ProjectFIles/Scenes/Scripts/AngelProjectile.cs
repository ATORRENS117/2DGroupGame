using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelProjectile : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Rigidbody2D rb;
    [SerializeField] float force;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity=new Vector2(direction.x, direction.y).normalized*force;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthManagement>().DamagePlayer(1);
            Destroy(gameObject);

        }
        if (collision.transform.tag == "Angels")
        {
            print("Nothing");
        }
        else
        {
            Destroy(gameObject);

        }
    }



}
