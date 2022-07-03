using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{

   

    public GameObject life2;
    public GameObject life3;
    public GameObject life4;
    public GameObject life5;
    public GameObject life2BG;
    public GameObject life3BG;
    public GameObject life4BG;
    public GameObject life5BG;
  

    public float health;
    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health == 80f)
        {
            life5.gameObject.SetActive(false);
            life5BG.gameObject.SetActive(true);
           
        }
         if (health == 60f)
        {
            life4.gameObject.SetActive(false);
            life4BG.gameObject.SetActive(true);
           
        }
         if (health == 40f)
        {
            life3.gameObject.SetActive(false);
            life3BG.gameObject.SetActive(true);
           
        }
         if (health == 20f)
        {
            life2.gameObject.SetActive(false);
            life2BG.gameObject.SetActive(true);
           
        }

        if (health <= 0f)
        {
            
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }
}
