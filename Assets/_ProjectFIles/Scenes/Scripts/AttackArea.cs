using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 1;
    private bool isFacingRight;
    public bool flipAttackAreaTrigger;
    [SerializeField] GameObject MovementScriptRef;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Enemy")
        {
            if (collider.GetComponent<HellEnemyHealth>() != null)
            {
                HellEnemyHealth health = collider.GetComponent<HellEnemyHealth>();
                health.Damage(damage);
            }
        }
        if (collider.transform.tag == "Angel")
        {
            AngelHealth AHealth=collider.GetComponent<AngelHealth>();
            if (AHealth.Angelhealth != 0)
            {
                AHealth.Damage(damage);
            }
        }
        else
        {
            print("COLLIDE BUT NOT DETECT");
            print("Collider is read as: " + collider.transform.tag);
        }
       
    }

    private void FixedUpdate()
    {
        if (flipAttackAreaTrigger)
        {
            flipAttackAreaTrigger = MovementScriptRef.GetComponent<PlayerMovement>().flipAttackArea;
            Flip();
            flipAttackAreaTrigger = false;
        }
    }
    private void Flip()
    {
        if (isFacingRight || !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
