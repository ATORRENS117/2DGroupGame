using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AngelAttackController : MonoBehaviour
{
    /*[SerializeField] private GameObject projectileScript;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject angel;
    private bool pauseFire = false;
    private float distance;
    private Vector2 playerPos;
    private Vector2 angelPos;
    public GameObject AngelProjectilePrefab;
    void Update()
    {
        distance = Vector2.Distance(angel.transform.position, player.transform.position);
        if (distance < 30f)
        {
          
            if (pauseFire==false)
            {
                print("Here?");
                //playerPos = player.transform.position;
                //angelPos=angel.transform.position;
                StartCoroutine(Fire());
                
            }
            
        }
    }
    private IEnumerator Fire()
    {
        pauseFire= true;
        print("Shouold fire");
        GameObject projectile = Instantiate(AngelProjectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-3.0f, 0f);
        yield return new WaitForSeconds(5);
        pauseFire= false;

    }*/
    //////
    public GameObject AngelProjectilePrefab;
    public Transform projectilePos;

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
        Instantiate(AngelProjectilePrefab, projectilePos.position,Quaternion.identity);
    }

}
