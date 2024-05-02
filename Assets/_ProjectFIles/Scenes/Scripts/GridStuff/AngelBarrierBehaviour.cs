using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AngelBarrierBehaviour : MonoBehaviour
{
    public bool cancelChase;
    private float distance;
    [SerializeField] GameObject charPathScript;
    [SerializeField] GameObject player;
    private void Update()
    {
        cancelChase = charPathScript.GetComponent<CharacterPathfindingMovementHandler>().resetPath;
        distance = Vector2.Distance(this.transform.position, player.transform.position);
        if (distance > 40f)
        {
            this.transform.position = new Vector3(828, 139);
            cancelChase = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "AngelBarrier")
        {
            this.transform.position = new Vector3(828, 139);
            cancelChase = true;

        }
        else
        {
            Debug.Log("Collided");
        }

    }


}
