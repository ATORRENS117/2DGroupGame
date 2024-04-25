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
        if (collider.GetComponent<HellEnemyHealth>() != null)
        {
            HellEnemyHealth health = collider.GetComponent<HellEnemyHealth>();
            health.Damage(damage);
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
