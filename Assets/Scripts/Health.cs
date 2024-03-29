using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHearth;
    public Sprite emptyHeart;


    // Update is called once per frame

    private void Start()
    {
        numOfHearts = hearts.Length;
        health = numOfHearts;
    }
    void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHearth;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            /*if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }*/
        }
    }

    public void AddHealth()
    {
        if(health < numOfHearts)
        {
            health++;
        }
    }
}
