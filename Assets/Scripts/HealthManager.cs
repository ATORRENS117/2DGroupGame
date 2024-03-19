using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagement : MonoBehaviour
{
    public int health = 5;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    [SerializeField] GameObject gameOver;

    private void Awake()
    {
        gameOver.SetActive(false);
    }
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Enemy")
        {
            if (health != 0)
            {


                health = health - 1;



                if (health == 0)
                {
                    gameOver.SetActive(true);

                }
                else
                {
                    StartCoroutine(GetHurt());
                }
            }


        }


    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(3, 7);
        yield return new WaitForSeconds(2);
        Physics2D.IgnoreLayerCollision(3, 7, false);
    }
}
