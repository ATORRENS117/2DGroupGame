using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class AngelAttackController : MonoBehaviour
{
   
    public GameObject AngelProjectilePrefab;
    [SerializeField] GameObject player;
    public Transform projectilePos;
    private float distance;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        distance = Vector2.Distance(this.transform.position, player.transform.position);
        if (distance < 30f)
        {
            Instantiate(AngelProjectilePrefab, projectilePos.position, Quaternion.identity);
        }
    }

}
